namespace Harvest.Invoices.Models;

using Common.Serialization;

/// <summary>
/// Defines the summary type for expense imports.
/// </summary>
public enum ExpenseImportSummaryType
{
    /// <summary>
    /// The expenses are summarized by project.
    /// </summary>
    [EnumStringValue("project")]
    Project,
    /// <summary>
    /// The expenses are summarized by category.
    /// </summary>
    [EnumStringValue("category")]
    Category,
    /// <summary>
    /// The expenses are summarized by person.
    /// </summary>
    [EnumStringValue("people")]
    People,
    /// <summary>
    /// The expenses are summarized by detail.
    /// </summary>
    [EnumStringValue("detailed")]
    Detailed
}