namespace Harvest.TimeEntries.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating a time entry by duration.
/// </summary>
public class CreateTimeEntryByDuration : CreateTimeEntry
{
    /// <summary>
    /// Gets or sets the current amount of time tracked.
    /// </summary>
    /// <remarks>
    /// If provided, the time entry will be created without a running timer.
    /// </remarks>
    [JsonProperty("hours")]
    public decimal? Hours { get; set; }
}