namespace Harvest.Reports.ProjectBudget.Models;

using Harvest.Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a project budget report.
/// </summary>
public class ProjectBudgetReport
{
    /// <summary>
    /// Gets or sets the ID of the client for the report.
    /// </summary>
    [JsonProperty("client_id")]
    public long? ClientId { get; set; }

    /// <summary>
    /// Gets or sets the name of the client for the report.
    /// </summary>
    [JsonProperty("client_name")]
    public string ClientName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the project for the report.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the name of the project for the report.
    /// </summary>
    [JsonProperty("project_name")]
    public string ProjectName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the budget is reset every month.
    /// </summary>
    [JsonProperty("budget_is_monthly")]
    public bool? BudgetIsMonthly { get; set; }

    /// <summary>
    /// Gets or sets the method by which the project is budgeted.
    /// </summary>
    [JsonProperty("budget_by")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public BudgetBy BudgetBy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the project is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets the budget in hours or money for the project when budgeting by time.
    /// </summary>
    [JsonProperty("budget")]
    public decimal? Budget { get; set; }

    /// <summary>
    /// Gets or sets the total hours or money spent against the project's budget.
    /// </summary>
    [JsonProperty("budget_spent")]
    public decimal? BudgetSpent { get; set; }

    /// <summary>
    /// Gets or sets the total hours or money remaining in the project's budget.
    /// </summary>
    [JsonProperty("budget_remaining")]
    public decimal? BudgetRemaining { get; set; }
}