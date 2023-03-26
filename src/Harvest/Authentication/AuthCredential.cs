namespace Harvest.Authentication;

using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Defines a credential capable of providing authentication information to the Harvest API.
/// </summary>
public abstract class AuthCredential
{
    /// <summary>
    /// Gets the access token of the Harvest account.
    /// </summary>
    public AccessToken AccessToken { get; protected set; }

    /// <summary>
    /// Authenticates a <see cref="HttpRequestMessage"/> with the Harvest API using the stored credentials.
    /// </summary>
    /// <param name="request">The request to authenticate.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public abstract Task AuthenticateRequestAsync(HttpRequestMessage request);
}