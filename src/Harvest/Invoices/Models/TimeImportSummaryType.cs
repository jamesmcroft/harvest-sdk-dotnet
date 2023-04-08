namespace Harvest.Invoices.Models;

using Common.Serialization;

/// <summary>
/// Defines the summary type for time entry imports.
/// </summary>
public enum TimeImportSummaryType
{
    /// <summary>
    /// The time entries are summarized by project.
    /// </summary>
    [EnumStringValue("project")] Project,

    /// <summary>
    /// The time entries are summarized by task.
    /// </summary>
    [EnumStringValue("task")] Task,

    /// <summary>
    /// The time entries are summarized by person.
    /// </summary>
    [EnumStringValue("people")] People,

    /// <summary>
    /// The time entries are summarized by detail.
    /// </summary>
    [EnumStringValue("detailed")] Detailed
}