namespace Harvest.Reports.Time.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail of a time report.
/// </summary>
public class TimeReportSummary
{
    /// <summary>
    /// Gets or sets the totaled hours for the given time frame, subject, and currency.
    /// </summary>
    [JsonProperty("total_hours")]
    public decimal? TotalHours { get; set; }

    /// <summary>
    /// Gets or sets the totaled billable hours for the given time frame, subject, and currency.
    /// </summary>
    [JsonProperty("billable_hours")]
    public decimal? BillableHours { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the expenses for this result.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the totaled billable amount for the billable hours.
    /// </summary>
    [JsonProperty("billable_amount")]
    public decimal? BillableAmount { get; set; }
}