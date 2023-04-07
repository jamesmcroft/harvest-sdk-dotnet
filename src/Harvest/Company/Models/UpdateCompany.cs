namespace Harvest.Company.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request for updating a company.
/// </summary>
public class UpdateCompany
{
    /// <summary>
    /// Gets or sets a value indicating whether time is tracked via durations or start and end times.
    /// </summary>
    [JsonProperty("wants_timestamp_timers")]
    public bool? WantsTimestampTimers { get; set; }

    /// <summary>
    /// Gets or sets the weekly capacity in seconds.
    /// </summary>
    [JsonProperty("weekly_capacity")]
    public int? WeeklyCapacity { get; set; }
}