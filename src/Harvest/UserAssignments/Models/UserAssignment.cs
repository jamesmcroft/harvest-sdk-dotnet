namespace Harvest.UserAssignments.Models;

using Common.Responses;
using Newtonsoft.Json;
using Projects.Models;
using Users.Models;

/// <summary>
/// Defines the detail of a user assignment.
/// </summary>
public class UserAssignment : Entry
{
    /// <summary>
    /// Gets or sets the project associated with the assignment.
    /// </summary>
    [JsonProperty("project")]
    public ProjectSummary Project { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the assignment.
    /// </summary>
    [JsonProperty("user")]
    public UserSummary User { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the assignment is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is a project manager on the project.
    /// </summary>
    [JsonProperty("is_project_manager")]
    public bool? IsProjectManager { get; set; }

    /// <summary>
    /// Gets or sets a value indicating which billable rate will be used on the project for this user when the project is <see cref="BillBy.People"/>.
    /// </summary>
    [JsonProperty("use_default_rates")]
    public bool? UseDefaultRates { get; set; }

    /// <summary>
    /// Gets or sets the custom rate used when the project is <see cref="BillBy.People"/> and <see cref="UseDefaultRates"/> is false.
    /// </summary>
    [JsonProperty("hourly_rate")]
    public decimal? HourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the budget used when the project is <see cref="BudgetBy.Person"/>.
    /// </summary>
    [JsonProperty("budget")]
    public decimal? Budget { get; set; }
}