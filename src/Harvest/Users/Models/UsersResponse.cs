namespace Harvest.Users.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of users.
/// </summary>
public class UsersResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the users in the current page.
    /// </summary>
    [JsonProperty("users")]
    public List<User> Users { get; set; }
}