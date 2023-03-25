namespace Harvest.Authentication;

/// <summary>
/// Defines a personal access token (PAT) credential capable of providing authentication information to the Harvest API.
/// </summary>
public class PATCredential : AuthCredential
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PATCredential"/> class with the specified token.
    /// </summary>
    /// <param name="token">The personal access token of the Harvest account.</param>
    public PATCredential(string token)
    {
        this.Token = token;
    }

    /// <summary>
    /// Gets the personal access token of the Harvest account.
    /// </summary>
    internal string Token { get; }
}