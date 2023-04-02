namespace Harvest.Roles.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of roles.
/// </summary>
public class RolesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the roles in the current page.
    /// </summary>
    [JsonProperty("roles")]
    public List<Role> Roles { get; set; }
}