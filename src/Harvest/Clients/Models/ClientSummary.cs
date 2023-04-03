namespace Harvest.Clients.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail of a client.
/// </summary>
public class ClientSummary : Entry
{
    /// <summary>
    /// Gets or sets the descriptive name of the client.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the currency of the client.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }
}