namespace Harvest.Projects.TaskAssignments.Models;

using Newtonsoft.Json;
using Projects.Models;

/// <summary>
/// Defines the detail for updating a task assignment for a project.
/// </summary>
public class UpdateTaskAssignment
{
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
    /// Gets or sets the rate used when the project's <see cref="BillBy"/> is <see cref="BillBy.Tasks"/>.
    /// </summary>
    [JsonProperty("hourly_rate")]
    public decimal? HourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the budget used when the project's <see cref="BudgetBy"/> is <see cref="BudgetBy.Task"/> or <see cref="BudgetBy.TaskFees"/>.
    /// </summary>
    [JsonProperty("budget")]
    public decimal? Budget { get; set; }
}