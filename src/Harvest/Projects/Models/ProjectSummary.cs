namespace Harvest.Projects.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail of a project.
/// </summary>
public class ProjectSummary : Entry
{
    /// <summary>
    /// Gets or sets the name of the project.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the code of the project.
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }
}