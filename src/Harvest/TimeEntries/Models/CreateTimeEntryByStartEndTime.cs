namespace Harvest.TimeEntries.Models;

using System;
using Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating a time entry by start and end time.
/// </summary>
public class CreateTimeEntryByStartEndTime : CreateTimeEntry
{
    /// <summary>
    /// Gets or sets the time the entry started. Defaults to the current time.
    /// </summary>
    [JsonProperty("started_time")]
    [JsonConverter(typeof(HarvestTimeValueConverter))]
    public TimeSpan StartedTime { get; set; } = DateTime.UtcNow.TimeOfDay;

    /// <summary>
    /// Gets or sets the time the entry ended.
    /// </summary>
    /// <remarks>
    /// If provided, the time entry will be created without a running timer.
    /// </remarks>
    [JsonProperty("ended_time")]
    [JsonConverter(typeof(HarvestTimeValueConverter))]
    public TimeSpan? EndedTime { get; set; }
}