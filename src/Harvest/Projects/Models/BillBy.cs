namespace Harvest.Projects.Models;

using Common.Serialization;

/// <summary>
/// Defines the bill by options for a project.
/// </summary>
public enum BillBy
{
    /// <summary>
    /// The project is not billable.
    /// </summary>
    [EnumStringValue("none")] None,

    /// <summary>
    /// The project is billable by people's billable rate per hour.
    /// </summary>
    [EnumStringValue("People")] People,

    /// <summary>
    /// The project is billable by the project's billable rate per hour.
    /// </summary>
    [EnumStringValue("Project")] Project,

    /// <summary>
    /// The project is billable by the project's task's billable rate per hour.
    /// </summary>
    [EnumStringValue("Tasks")] Tasks,
}