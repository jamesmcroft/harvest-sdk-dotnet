namespace Harvest.Users.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail of a user.
/// </summary>
public class UserSummary : Entry
{
    private string name;

    /// <summary>
    /// Gets or sets the name for the user.
    /// </summary>
    [JsonProperty("name")]
    public string Name
    {
        get => this.GetName();
        set => this.name = value;
    }

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

    private string GetName()
    {
        if (!string.IsNullOrEmpty(this.name))
        {
            return this.name;
        }

        if (string.IsNullOrEmpty(this.FirstName) && string.IsNullOrEmpty(this.LastName))
        {
            return string.Empty;
        }

        if (string.IsNullOrEmpty(this.FirstName))
        {
            return this.LastName;
        }

        return string.IsNullOrEmpty(this.LastName) ? this.FirstName : $"{this.FirstName} {this.LastName}";
    }
}