namespace Harvest.Authentication;

using System.Net.Http;
using System.Threading.Tasks;

/// <summary>
/// Defines a personal access token (PAT) credential capable of providing authentication information to the Harvest API.
/// </summary>
public class PATCredential : AuthCredential
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PATCredential"/> class with the specified token.
    /// </summary>
    /// <param name="accessToken">The personal access token of the Harvest account.</param>
    public PATCredential(string accessToken)
    {
        this.AccessToken = new AccessToken(accessToken);
    }

    /// <inheritdoc />
    public override Task AuthenticateRequestAsync(HttpRequestMessage request)
    {
        request.Headers.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", this.AccessToken.Token);
        return Task.CompletedTask;
    }
}