namespace Harvest.TimeEntries.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of time entries.
/// </summary>
public class TimeEntriesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the time entries in the current page.
    /// </summary>
    [JsonProperty("time_entries")]
    public List<TimeEntry> TimeEntries { get; set; }
}