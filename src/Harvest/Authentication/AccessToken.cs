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
    /// <param name="accessToken">The bearer access token value.</param>
    /// <param name="expiresOn">The time when the provided bearer access token expires.</param>
    public AccessToken(string accessToken, DateTimeOffset expiresOn)
    {
        this.Token = accessToken;
        this.ExpiresOn = expiresOn;
    }

    /// <summary>
    /// Gets the bearer access token value.
    /// </summary>
    public string Token { get; }

    /// <summary>
    /// Gets the time when the provided bearer access token expires.
    /// </summary>
    public DateTimeOffset ExpiresOn { get; }

    /// <inheritdoc />
    public override bool Equals(object obj)
    {
        if (obj is AccessToken accessToken)
        {
            return this.Equals(accessToken);
        }

        return false;
    }

    /// <summary>
    /// Determines whether the specified <see cref="AccessToken"/> is equal to the current <see cref="AccessToken"/>.
    /// </summary>
    /// <param name="other">The object to compare with the current object.</param>
    /// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
    protected bool Equals(AccessToken other)
    {
        return this.Token == other.Token && this.ExpiresOn.Equals(other.ExpiresOn);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(this.Token, this.ExpiresOn);
    }
}