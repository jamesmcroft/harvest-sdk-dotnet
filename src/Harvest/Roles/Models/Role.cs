namespace Harvest.Roles.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for a role.
/// </summary>
public class Role : Entry
{
    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the IDs of the users assigned to the role.
    /// </summary>
    [JsonProperty("user_ids")]
    public List<long> UserIds { get; set; }
}