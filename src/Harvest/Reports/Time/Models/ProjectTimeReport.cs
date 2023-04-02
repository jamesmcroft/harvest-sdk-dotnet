namespace Harvest.Reports.Time.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a project's time report.
/// </summary>
public class ProjectTimeReport : ClientTimeReport
{
    /// <summary>
    /// Gets or sets the ID of the project for the time report.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the name of the project for the time report.
    /// </summary>
    [JsonProperty("project_name")]
    public string ProjectName { get; set; }
}