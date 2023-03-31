namespace Harvest.Tasks.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail for a task.
/// </summary>
public class TaskSummary : Entry
{
    /// <summary>
    /// Gets or sets the name of the task.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}