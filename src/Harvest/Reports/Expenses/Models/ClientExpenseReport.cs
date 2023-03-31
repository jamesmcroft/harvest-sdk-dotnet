namespace Harvest.Reports.Expenses.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a client's expense report.
/// </summary>
public class ClientExpenseReport : ExpenseReportSummary
{
    /// <summary>
    /// Gets or sets the ID of the client for the expense report.
    /// </summary>
    [JsonProperty("client_id")]
    public long? ClientId { get; set; }

    /// <summary>
    /// Gets or sets the name of the client for the expense report.
    /// </summary>
    [JsonProperty("client_name")]
    public string ClientName { get; set; }
}