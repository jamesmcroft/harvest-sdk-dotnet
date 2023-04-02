namespace Harvest.Reports.Time.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a task's time report.
/// </summary>
public class TaskTimeReport : TimeReportSummary
{
    /// <summary>
    /// Gets or sets the ID of the task for the time report.
    /// </summary>
    [JsonProperty("task_id")]
    public long? TaskId { get; set; }

    /// <summary>
    /// Gets or sets the name of the task for the time report.
    /// </summary>
    [JsonProperty("task_name")]
    public string TaskName { get; set; }
}