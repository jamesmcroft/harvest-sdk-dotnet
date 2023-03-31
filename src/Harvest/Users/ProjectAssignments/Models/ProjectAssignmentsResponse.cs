namespace Harvest.Users.ProjectAssignments.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of user's project assignments.
/// </summary>
public class ProjectAssignmentsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the user's project assignments in the current page.
    /// </summary>
    [JsonProperty("project_assignments")]
    public List<ProjectAssignment> ProjectAssignments { get; set; }
}