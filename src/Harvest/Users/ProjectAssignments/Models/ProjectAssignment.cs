namespace Harvest.Users.ProjectAssignments.Models;

using System.Collections.Generic;
using Clients.Models;
using Common.Responses;
using Newtonsoft.Json;
using Projects.Models;
using Projects.TaskAssignments.Models;

/// <summary>
/// Defines the detail for a user's project assignment.
/// </summary>
public class ProjectAssignment : Entry
{
    /// <summary>
    /// Gets or sets a value indicating whether the project assignment is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is a project manager.
    /// </summary>
    [JsonProperty("is_project_manager")]
    public bool? IsProjectManager { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the billable rates will be used for the user or the custom rates for the project assignment.
    /// </summary>
    [JsonProperty("use_default_rates")]
    public bool? UseDefaultRates { get; set; }

    /// <summary>
    /// Gets or sets the custom rate used when the <see cref="UseDefaultRates"/> is false.
    /// </summary>
    [JsonProperty("hourly_rate")]
    public decimal? HourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the budget for the project assignment.
    /// </summary>
    [JsonProperty("budget")]
    public decimal? Budget { get; set; }

    /// <summary>
    /// Gets or sets the project for the assignment.
    /// </summary>
    [JsonProperty("project")]
    public ProjectSummary Project { get; set; }

    /// <summary>
    /// Gets or sets the client for the project.
    /// </summary>
    [JsonProperty("client")]
    public ClientSummary Client { get; set; }

    /// <summary>
    /// Gets or sets the task assignments for the project.
    /// </summary>
    [JsonProperty("task_assignments")]
    public List<TaskAssignment> TaskAssignments { get; set; }
}