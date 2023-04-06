namespace Harvest.TimeEntries.Models;

using System;
using Newtonsoft.Json;

/// <summary>
/// Defines the base detail for creating a time entry.
/// </summary>
public abstract class CreateTimeEntry
{
    /// <summary>
    /// Gets or sets the ID of the user associated with this time entry.
    /// </summary>
    /// <remarks>
    /// If the user is not specified, the currently authenticated user will be used.
    /// </remarks>
    [JsonProperty("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the project associated with this time entry.
    /// </summary>
    [JsonProperty("project_id")]
    public long ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the task associated with this time entry.
    /// </summary>
    [JsonProperty("task_id")]
    public long TaskId { get; set; }

    /// <summary>
    /// Gets or sets the date the time entry was spent.
    /// </summary>
    [JsonProperty("spent_date")]
    public DateTime SpentDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the notes/description associated with the time entry.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the ID, group ID, account ID, permalink, service, or service icon URL of the associated external reference.
    /// </summary>
    [JsonProperty("external_reference")]
    public string ExternalReference { get; set; }
}