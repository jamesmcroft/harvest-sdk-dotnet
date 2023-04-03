namespace Harvest.Projects.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of projects.
/// </summary>
public class ProjectsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the projects in the current page.
    /// </summary>
    [JsonProperty("projects")]
    public List<Project> Projects { get; set; }
}