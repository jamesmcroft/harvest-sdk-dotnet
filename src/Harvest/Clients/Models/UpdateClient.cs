namespace Harvest.Clients.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request to update a client.
/// </summary>
public class UpdateClient
{
    /// <summary>
    /// Gets or sets the descriptive name of the client.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

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
    /// Gets or sets the currency of the client.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }
}