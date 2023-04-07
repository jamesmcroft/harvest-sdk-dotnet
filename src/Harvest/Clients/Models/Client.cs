namespace Harvest.Clients.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail for a client.
/// </summary>
public class Client : ClientSummary
{
    /// <summary>
    /// Gets or sets a value indicating whether the client is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the physical address for the client.
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    /// Gets or sets the URL for the client's invoice dashboard.
    /// </summary>
    [JsonProperty("statement_key")]
    public string StatementKey { get; set; }
}