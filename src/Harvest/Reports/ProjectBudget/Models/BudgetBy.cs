namespace Harvest.Reports.ProjectBudget.Models;

using Common.Serialization;

/// <summary>
/// Defines the budget by options for a project budget report.
/// </summary>
public enum BudgetBy
{
    /// <summary>
    /// The budget is by hours per project.
    /// </summary>
    [EnumStringValue("project")] Project,

    /// <summary>
    /// The budget is by total project fees.
    /// </summary>
    [EnumStringValue("project_cost")] ProjectCost,

    /// <summary>
    /// The budget is by hours per task.
    /// </summary>
    [EnumStringValue("task")] Task,

    /// <summary>
    /// The budget is by fees per task.
    /// </summary>
    [EnumStringValue("task_fees")] TaskFees,

    /// <summary>
    /// The budget is by hours per person.
    /// </summary>
    [EnumStringValue("person")] Person,

    /// <summary>
    /// The budget is not set.
    /// </summary>
    [EnumStringValue("none")] None
}