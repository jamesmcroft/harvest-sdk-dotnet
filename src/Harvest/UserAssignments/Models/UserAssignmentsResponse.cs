namespace Harvest.UserAssignments.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of user assignments.
/// </summary>
public class UserAssignmentsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the user assignments in the current page.
    /// </summary>
    [JsonProperty("user_assignments")]
    public List<UserAssignment> UserAssignments { get; set; }
}