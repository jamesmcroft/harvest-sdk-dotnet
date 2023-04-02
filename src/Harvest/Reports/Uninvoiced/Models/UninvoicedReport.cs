namespace Harvest.Reports.Uninvoiced.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of an uninvoiced report.
/// </summary>
public class UninvoicedReport
{
    /// <summary>
    /// Gets or sets the ID of the client for the report.
    /// </summary>
    [JsonProperty("client_id")]
    public long? ClientId { get; set; }

    /// <summary>
    /// Gets or sets the name of the client for the report.
    /// </summary>
    [JsonProperty("client_name")]
    public string ClientName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the project for the report.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the name of the project for the report.
    /// </summary>
    [JsonProperty("project_name")]
    public string ProjectName { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the expenses for this report.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the total hours for the report.
    /// </summary>
    [JsonProperty("total_hours")]
    public decimal? TotalHours { get; set; }

    /// <summary>
    /// Gets or sets the total hours that have not been invoiced for the report.
    /// </summary>
    [JsonProperty("uninvoiced_hours")]
    public decimal? UninvoicedHours { get; set; }

    /// <summary>
    /// Gets or sets the total amount for billable expenses that have not been invoiced for the report.
    /// </summary>
    [JsonProperty("uninvoiced_expenses")]
    public decimal? UninvoicedExpenses { get; set; }

    /// <summary>
    /// Gets or sets the total amount (time and expenses) that have not been invoiced for the report.
    /// </summary>
    [JsonProperty("uninvoiced_amount")]
    public decimal? UninvoicedAmount { get; set; }
}