namespace Harvest.Reports.Time.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a client's time report.
/// </summary>
public class ClientTimeReport : TimeReportSummary
{
    /// <summary>
    /// Gets or sets the ID of the client for the time report.
    /// </summary>
    [JsonProperty("client_id")]
    public long? ClientId { get; set; }

    /// <summary>
    /// Gets or sets the name of the client for the time report.
    /// </summary>
    [JsonProperty("client_name")]
    public string ClientName { get; set; }
}