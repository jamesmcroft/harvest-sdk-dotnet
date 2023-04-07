namespace Harvest.Tasks.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of tasks.
/// </summary>
public class TasksResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the tasks in the current page.
    /// </summary>
    [JsonProperty("tasks")]
    public List<TaskEntry> Tasks { get; set; }
}