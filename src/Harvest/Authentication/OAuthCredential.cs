namespace Harvest.Authentication;

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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
    /// <param name="scopes">The scopes to request from the Harvest API. Defaults to "harvest:all".</param>
    /// <param name="responseType">The OAuth2 response type to use when authenticating the client. Defaults to "code".</param>
    public OAuthCredential(
        string clientId,
        string clientSecret,
        Uri redirectUri,
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
}