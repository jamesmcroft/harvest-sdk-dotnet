namespace Harvest.TimeEntries.Models;

using System;
using Harvest.Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for updating a time entry.
/// </summary>
public class UpdateTimeEntry
{
    /// <summary>
    /// Gets or sets the ID of the project associated with this time entry.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the task associated with this time entry.
    /// </summary>
    [JsonProperty("task_id")]
    public long? TaskId { get; set; }

    /// <summary>
    /// Gets or sets the date the time entry was spent.
    /// </summary>
    [JsonProperty("spent_date")]
    public DateTime? SpentDate { get; set; }

    /// <summary>
    /// Gets or sets the time the entry started. Defaults to the current time.
    /// </summary>
    [JsonProperty("started_time")]
    [JsonConverter(typeof(HarvestTimeValueConverter))]
    public TimeSpan? StartedTime { get; set; }

    /// <summary>
    /// Gets or sets the time the entry ended.
    /// </summary>
    [JsonProperty("ended_time")]
    [JsonConverter(typeof(HarvestTimeValueConverter))]
    public TimeSpan? EndedTime { get; set; }

    /// <summary>
    /// Gets or sets the current amount of time tracked.
    /// </summary>
    [JsonProperty("hours")]
    public decimal? Hours { get; set; }

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