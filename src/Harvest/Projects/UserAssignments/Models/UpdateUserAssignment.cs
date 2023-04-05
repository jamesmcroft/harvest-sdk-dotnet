namespace Harvest.Projects.UserAssignments.Models;

using Newtonsoft.Json;
using Projects.Models;

/// <summary>
/// Defines the detail for updating a user assignment.
/// </summary>
public class UpdateUserAssignment
{
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