namespace Harvest.Users.Models;

using Newtonsoft.Json;

using System.Collections.Generic;

/// <summary>
/// Defines the detail for creating a user.
/// </summary>
public class CreateUser
{
    /// <summary>
    /// Gets or sets the first name for the user.
    /// </summary>
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name for the user.
    /// </summary>
    [JsonProperty("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address for the user.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the telephone number for the user.
    /// </summary>
    [JsonProperty("telephone")]
    public string Telephone { get; set; }

    /// <summary>
    /// Gets or sets the time zone for the user.
    /// </summary>
    [JsonProperty("timezone")]
    public string TimeZone { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user has access to all future projects.
    /// </summary>
    [JsonProperty("has_access_to_all_future_projects")]
    public bool? HasAccessToAllFutureProjects { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is a contractor.
    /// </summary>
    [JsonProperty("is_contractor")]
    public bool? IsContractor { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the number of hours per week the user is available to work in seconds.
    /// </summary>
    [JsonProperty("weekly_capacity")]
    public int? WeeklyCapacity { get; set; }

    /// <summary>
    /// Gets or sets the default billable hourly rate for the user.
    /// </summary>
    [JsonProperty("default_hourly_rate")]
    public decimal? DefaultHourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the cost rate to use for the user when calculating a project cost vs billable.
    /// </summary>
    [JsonProperty("cost_rate")]
    public decimal? CostRate { get; set; }

    /// <summary>
    /// Gets or sets the descriptive names of the business roles assigned to the user.
    /// </summary>
    [JsonProperty("roles")]
    public List<string> Roles { get; set; }

    /// <summary>
    /// Gets or sets the access roles that determine the user permissions in Harvest.
    /// </summary>
    [JsonProperty("access_roles")]
    public List<string> AccessRoles { get; set; }
}