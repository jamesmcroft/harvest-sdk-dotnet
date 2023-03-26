namespace Harvest.Authentication;

using Newtonsoft.Json;

/// <summary>
/// Defines a response from the Harvest API containing authentication information.
/// </summary>
internal class AuthResponse
{
    /// <summary>
    /// Gets or sets the access token.
    /// </summary>
    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    /// <summary>
    /// Gets or sets the refresh token.
    /// </summary>
    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets the token type.
    /// </summary>
    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    /// <summary>
    /// Gets or sets the expiry time in seconds.
    /// </summary>
    [JsonProperty("expires_in")]
    public long ExpiresIn { get; set; }

    /// <summary>
    /// Gets or sets the scope.
    /// </summary>
    [JsonProperty("scope")]
    public string Scope { get; set; }
}