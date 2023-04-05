namespace Harvest.Projects.TaskAssignments.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of task assignments.
/// </summary>
public class TaskAssignmentsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the task assignments in the current page.
    /// </summary>
    [JsonProperty("task_assignments")]
    public List<TaskAssignment> TaskAssignments { get; set; }
}