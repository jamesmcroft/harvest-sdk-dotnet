namespace Harvest.Users.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail of a user.
/// </summary>
public class UserSummary : Entry
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
}