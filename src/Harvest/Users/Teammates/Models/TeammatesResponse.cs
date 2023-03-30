namespace Harvest.Users.Teammates.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;
using Users.Models;

/// <summary>
/// Defines the response for a list of user's teammates.
/// </summary>
public class TeammatesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the user's teammates in the current page.
    /// </summary>
    [JsonProperty("teammates")]
    public List<UserSummary> Teammates { get; set; }
}