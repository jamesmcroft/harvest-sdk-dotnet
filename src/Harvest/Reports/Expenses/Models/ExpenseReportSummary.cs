namespace Harvest.Reports.Expenses.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail of an expense report.
/// </summary>
public class ExpenseReportSummary
{
    /// <summary>
    /// Gets or sets the totaled cost for all expenses for the given time frame, subject, and currency.
    /// </summary>
    [JsonProperty("total_amount")]
    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the totaled cost for billable expenses for the given time frame, subject, and currency.
    /// </summary>
    [JsonProperty("billable_amount")]
    public decimal? BillableAmount { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the expenses for this result.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }
}