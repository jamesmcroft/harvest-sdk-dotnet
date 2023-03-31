namespace Harvest.Reports.Expenses.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a project's expense report.
/// </summary>
public class ProjectExpenseReport : ClientExpenseReport
{
    /// <summary>
    /// Gets or sets the ID of the project for the expense report.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the name of the project for the expense report.
    /// </summary>
    [JsonProperty("project_name")]
    public string ProjectName { get; set; }
}