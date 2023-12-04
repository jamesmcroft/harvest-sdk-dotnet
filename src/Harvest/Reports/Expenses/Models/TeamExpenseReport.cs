namespace Harvest.Reports.Expenses.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a team's expense report.
/// </summary>
public class TeamExpenseReport : ExpenseReportSummary
{
    /// <summary>
    /// Gets or sets the ID of the team user for the expense report.
    /// </summary>
    [JsonProperty("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the team user for the expense report.
    /// </summary>
    [JsonProperty("user_name")]
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the team user is a contractor.
    /// </summary>
    [JsonProperty("is_contractor")]
    public bool? IsContractor { get; set; }
}