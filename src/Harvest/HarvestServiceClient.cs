namespace Harvest;

using Authentication;
using Common.Requests;

/// <summary>
/// Defines the client used to communicate with the Harvest API.
/// </summary>
public partial class HarvestServiceClient
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HarvestServiceClient"/> class with the specified authentication credential.
    /// </summary>
    /// <param name="authCredential">The authentication credential used to authenticate the client.</param>
    public HarvestServiceClient(AuthCredential authCredential) : this(new HarvestRequestAdapter(authCredential))
    {
        this.authCredential = authCredential;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HarvestServiceClient"/> class with the specified request adapter.
    /// </summary>
    /// <param name="requestAdapter">The request adapter for sending requests.</param>
    public HarvestServiceClient(HarvestRequestAdapter requestAdapter)
    {
        this.RequestAdapter = requestAdapter;
    }

    /// <summary>
    /// Gets the <see cref="HarvestRequestAdapter"/> for sending requests.
    /// </summary>
    public HarvestRequestAdapter RequestAdapter { get; }
}