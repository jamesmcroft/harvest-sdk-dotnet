namespace Harvest.Users.Teammates.Models;

using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a user's teammates.
/// </summary>
public class UserTeammates
{
    /// <summary>
    /// Gets or sets the full list of user IDs to be assigned as teammates to the user.
    /// </summary>
    /// <remarks>
    /// This list will replace the user's current list of teammates.
    /// </remarks>
    [JsonProperty("teammate_ids")]
    public List<long> TeammateIds { get; set; }
}