namespace Harvest.Projects.TaskAssignments.Models;

using Common.Responses;
using Newtonsoft.Json;
using Projects.Models;
using Tasks.Models;

/// <summary>
/// Defines the detail for a task assignment for a project.
/// </summary>
public class TaskAssignment : Entry
{
    /// <summary>
    /// Gets or sets the project for the task assignment.
    /// </summary>
    [JsonProperty("project")]
    public ProjectSummary Project { get; set; }

    /// <summary>
    /// Gets or sets the task for the task assignment.
    /// </summary>
    [JsonProperty("task")]
    public TaskSummary Task { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the task assignment is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the task assignment is billable.
    /// </summary>
    [JsonProperty("billable")]
    public bool? Billable { get; set; }

    /// <summary>
    /// Gets or sets the rate used when the project's BillBy is Tasks.
    /// </summary>
    [JsonProperty("hourly_rate")]
    public decimal? HourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the budget used when the project's BudgetBy is Task or TaskFees.
    /// </summary>
    [JsonProperty("budget")]
    public decimal? Budget { get; set; }
}