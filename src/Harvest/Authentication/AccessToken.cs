namespace Harvest.Authentication;

using System;

/// <summary>
/// Defines a bearer access token with expiry information.
/// </summary>
public class AccessToken
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AccessToken"/> class with the specified access token value and expiry information.
    /// </summary>
    /// <param name="token">The bearer access token value.</param>
    /// <param name="expiresOn">The time when the provided bearer access token expires.</param>
    /// <param name="refreshToken">The refresh token value.</param>
    public AccessToken(string token, DateTimeOffset expiresOn = default, string refreshToken = default)
    {
        this.Token = token;
        this.ExpiresOn = expiresOn;
        this.RefreshToken = refreshToken;
    }

    /// <summary>
    /// Gets the bearer access token value.
    /// </summary>
    public string Token { get; private set; }

    /// <summary>
    /// Gets the time when the provided bearer access token expires.
    /// </summary>
    public DateTimeOffset ExpiresOn { get; private set; }

    /// <summary>
    /// Gets the refresh token value.
    /// </summary>
    public string RefreshToken { get; private set; }

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (obj is AccessToken accessToken)
        {
            return this.Equals(accessToken);
        }

        return false;
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        unchecked
        {
            int hashCode = (this.Token != null ? this.Token.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ this.ExpiresOn.GetHashCode();
            hashCode = (hashCode * 397) ^ (this.RefreshToken != null ? this.RefreshToken.GetHashCode() : 0);
            return hashCode;
        }
    }

    /// <summary>
    /// Updates the access token with the specified values.
    /// </summary>
    /// <param name="accessToken">The bearer access token value.</param>
    /// <param name="expiresIn">The time, in seconds, when the provided bearer access token expires.</param>
    /// <param name="refreshToken">The refresh token value.</param>
    internal void Update(string accessToken, long expiresIn, string refreshToken)
    {
        this.Token = accessToken;
        this.ExpiresOn = DateTimeOffset.UtcNow.AddSeconds(expiresIn);
        this.RefreshToken = refreshToken;
    }

    /// <summary>
    /// Determines whether the access token requires a refresh.
    /// </summary>
    /// <returns><see langword="true"/> if the access token requires a refresh; otherwise, <see langword="false"/>.</returns>
    internal bool TokenRefreshRequired()
    {
        return this.ExpiresOn < DateTimeOffset.UtcNow.AddMinutes(5) && !string.IsNullOrEmpty(this.RefreshToken);
    }

    /// <summary>
    /// Determines whether the specified <see cref="AccessToken"/> is equal to the current <see cref="AccessToken"/>.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
    protected bool Equals(AccessToken other)
    {
        return this.Token == other.Token && this.ExpiresOn.Equals(other.ExpiresOn) && this.RefreshToken == other.RefreshToken;
    }
}