namespace Harvest.Authentication;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines an OAuth-based credential capable of providing authentication information to the Harvest API.
/// </summary>
public class OAuthCredential : AuthCredential
{
    private string authState;

    /// <summary>
    /// Initializes a new instance of the <see cref="OAuthCredential"/> class with the specified client ID, client secret, OAuth2 response type, and optional redirect URI.
    /// </summary>
    /// <param name="clientId">The client (application) ID of the Harvest application.</param>
    /// <param name="clientSecret">A client secret that was generated for the Harvest application used to authenticate the client.</param>
    /// <param name="redirectUri">The redirect URL that starts with the redirect URL registered with the Harvest application.</param>
    /// <param name="accessToken">The access token detail that has previously been obtained from the Harvest API.</param>
    /// <param name="scopes">The scopes to request from the Harvest API. Defaults to "harvest:all".</param>
    /// <param name="responseType">The OAuth2 response type to use when authenticating the client. Defaults to "code".</param>
    /// <exception cref="ArgumentException">The response type must be either "code" or "token".</exception>
    public OAuthCredential(
        string clientId,
        string clientSecret,
        Uri redirectUri,
        AccessToken accessToken = default,
        string scopes = Harvest.Authentication.Scopes.HarvestAll,
        string responseType = "code")
    {
        if (responseType != "code" && responseType != "token")
        {
            throw new ArgumentException(
                "The response type must be either \"code\" or \"token\".",
                nameof(responseType));
        }

        this.ClientId = clientId;
        this.ClientSecret = clientSecret;
        this.ResponseType = responseType;
        this.Scopes = scopes;
        this.RedirectUri = redirectUri;
        this.AccessToken = accessToken;
    }

    /// <summary>
    /// Gets the client (application) ID of the Harvest application.
    /// </summary>
    internal string ClientId { get; }

    /// <summary>
    /// Gets the client secret that was generated for the Harvest application used to authenticate the client.
    /// </summary>
    internal string ClientSecret { get; }

    /// <summary>
    /// Gets the optional customized redirect URL that starts with the redirect URL registered with the Harvest application.
    /// </summary>
    internal Uri RedirectUri { get; }

    /// <summary>
    /// Gets the scopes to request from the Harvest API.
    /// </summary>
    internal string Scopes { get; }

    /// <summary>
    /// Gets the OAuth2 response type to use when authenticating the client.
    /// </summary>
    internal string ResponseType { get; }

    /// <summary>
    /// Builds the authorization URL for the Harvest API that can be used to authenticate the client.
    /// </summary>
    /// <returns>A <see cref="Uri"/> that can be used to authenticate the client.</returns>
    public Uri BuildAuthorizationUrl()
    {
        string GenerateAuthState()
        {
            using var random = new RNGCryptoServiceProvider();
            byte[] data = new byte[32];
            random.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        string ToQueryString(IEnumerable<KeyValuePair<string, string>> query)
        {
            var builder = new StringBuilder();
            bool first = true;

            foreach (KeyValuePair<string, string> item in query)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    builder.Append("&");
                }

                if (item.Value != null)
                {
                    builder.Append(Uri.EscapeDataString(item.Key)).Append("=").Append(Uri.EscapeDataString(item.Value));
                }
            }

            return builder.ToString();
        }

        this.authState = string.IsNullOrEmpty(this.authState) ? GenerateAuthState() : this.authState;

        var query = new Dictionary<string, string>
        {
            { "client_id", this.ClientId },
            { "redirect_uri", this.RedirectUri.ToString() },
            { "state", this.authState },
            { "scope", this.Scopes },
            { "response_type", this.ResponseType }
        };

        return new UriBuilder("https://id.getharvest.com/oauth2/authorize") { Query = ToQueryString(query) }.Uri;
    }

    /// <summary>
    /// Finalizes the authorization process initiated by the <see cref="BuildAuthorizationUrl"/> value by exchanging the authorization code for an access token.
    /// </summary>
    /// <param name="callbackUri">The callback URL that was used to redirect the user back to the application.</param>
    /// <param name="state">The state that was provided when the authorization URL was generated. Defaults to the state generated by calling <see cref="BuildAuthorizationUrl"/> if not provided.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous operation.</returns>
    /// <exception cref="InvalidOperationException">Thrown when there is an error during the authorization process.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task AuthorizeAsync(Uri callbackUri, string state = default)
    {
        NameValueCollection query = System.Web.HttpUtility.ParseQueryString(callbackUri.Query);

        if (!query.TryGetValue("state", out string urlState) || urlState != (state ?? this.authState))
        {
            throw new InvalidOperationException(
                "The state returned by the OAuth provider does not match the state provided.");
        }

        AuthResponse authResponse = null;

        if (query.TryGetValue("token_type", out string tokenType) &&
            query.TryGetValue("access_token", out string accessToken))
        {
            query.TryGetValue("expires_in", out string expiresIn);

            authResponse = new AuthResponse
            {
                TokenType = tokenType,
                AccessToken = accessToken,
                ExpiresIn = long.TryParse(expiresIn, out long expiresInValue) ? expiresInValue : 0
            };
        }
        else if (query.TryGetValue("code", out string code))
        {
            var client = new HttpClient();

            var authCodeRequest =
                new HttpRequestMessage(HttpMethod.Post, "https://id.getharvest.com/api/v2/oauth2/token")
                {
                    Content = new FormUrlEncodedContent(
                        new Dictionary<string, string>
                        {
                            { "client_id", this.ClientId },
                            { "client_secret", this.ClientSecret },
                            { "code", code },
                            { "grant_type", "authorization_code" }
                        })
                };

            HttpResponseMessage authCodeResponse = await client.SendAsync(authCodeRequest);

            if (authCodeResponse.IsSuccessStatusCode)
            {
                string authCodeResponseBody = await authCodeResponse.Content.ReadAsStringAsync();
                authResponse = JsonConvert.DeserializeObject<AuthResponse>(authCodeResponseBody);
            }
            else
            {
                throw new InvalidOperationException("The OAuth code could not be exchanged for an access token.");
            }
        }

        if (authResponse == null)
        {
            throw new InvalidOperationException("The OAuth credential could not be authenticated.");
        }

        this.SetAccessToken(authResponse);
    }

    /// <inheritdoc />
    /// <exception cref="InvalidOperationException">The OAuth credential has not been authenticated.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public override async Task AuthenticateRequestAsync(HttpRequestMessage request)
    {
        if (this.AccessToken == null)
        {
            throw new InvalidOperationException("The OAuth credential has not been authenticated.");
        }

        if (this.AccessToken.TokenRefreshRequired())
        {
            var client = new HttpClient();

            var authRefreshRequest =
                new HttpRequestMessage(HttpMethod.Post, "https://id.getharvest.com/api/v2/oauth2/token")
                {
                    Content = new FormUrlEncodedContent(
                        new Dictionary<string, string>
                        {
                            { "client_id", this.ClientId },
                            { "client_secret", this.ClientSecret },
                            { "refresh_token", this.AccessToken.RefreshToken },
                            { "grant_type", "refresh_token" }
                        })
                };

            HttpResponseMessage authRefreshResponse = await client.SendAsync(authRefreshRequest);

            if (authRefreshResponse.IsSuccessStatusCode)
            {
                AuthResponse authResponse =
                    JsonConvert.DeserializeObject<AuthResponse>(await authRefreshResponse.Content.ReadAsStringAsync());
                this.SetAccessToken(authResponse);
            }
            else
            {
                throw new InvalidOperationException("The OAuth credential could not be refreshed.");
            }
        }

        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.AccessToken.Token);
    }

    private void SetAccessToken(AuthResponse authResponse)
    {
        if (this.AccessToken == null)
        {
            this.AccessToken = new AccessToken(authResponse.AccessToken,
                DateTimeOffset.UtcNow.AddSeconds(authResponse.ExpiresIn), authResponse.RefreshToken);
        }
        else
        {
            this.AccessToken.Update(authResponse.AccessToken, authResponse.ExpiresIn,
                authResponse.RefreshToken);
        }
    }
}