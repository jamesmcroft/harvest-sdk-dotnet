namespace Harvest;

using Authentication;

/// <summary>
/// Defines the client used to communicate with the Harvest API.
/// </summary>
public class HarvestServiceClient
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HarvestServiceClient"/> class with the specified authentication credential.
    /// </summary>
    /// <param name="authCredential">The authentication credential used to authenticate the client.</param>
    public HarvestServiceClient(AuthCredential authCredential)
    {
        this.AuthCredential = authCredential;
    }

    /// <summary>
    /// Gets the authentication credential used to authenticate the client.
    /// </summary>
    public AuthCredential AuthCredential { get; }
}