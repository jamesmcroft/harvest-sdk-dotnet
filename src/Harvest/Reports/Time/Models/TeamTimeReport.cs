namespace Harvest.Reports.Time.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a team's time report.
/// </summary>
public class TeamTimeReport : TimeReportSummary
{
    /// <summary>
    /// Gets or sets the ID of the team user for the time report.
    /// </summary>
    [JsonProperty("user_id")]
    public long? UserId { get; set; }

    /// <summary>
    /// Gets or sets the name of the team user for the time report.
    /// </summary>
    [JsonProperty("user_name")]
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the team user is a contractor.
    /// </summary>
    [JsonProperty("is_contractor")]
    public bool? IsContractor { get; set; }

    /// <summary>
    /// Gets or sets the number of hours per week this person is available to work in seconds, in half hour increments.
    /// </summary>
    [JsonProperty("weekly_capacity")]
    public int? WeeklyCapacity { get; set; }

    /// <summary>
    /// Gets or sets the URL to the user's avatar image.
    /// </summary>
    [JsonProperty("avatar_url")]
    public string AvatarUrl { get; set; }
}