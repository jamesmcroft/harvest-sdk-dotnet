namespace Harvest.Projects.Models;

using System;
using Harvest.Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for creating a project.
/// </summary>
public class CreateProject
{
    /// <summary>
    /// Gets or sets the ID of the client associated with the project.
    /// </summary>
    [JsonProperty("client_id")]
    public long ClientId { get; set; }

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

    /// <summary>
    /// Gets or sets a value indicating whether the project is active.
    /// </summary>
    [JsonProperty("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the project is billable.
    /// </summary>
    [JsonProperty("is_billable")]
    public bool IsBillable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the project is a fixed-fee project.
    /// </summary>
    [JsonProperty("is_fixed_fee")]
    public bool? IsFixedFee { get; set; }

    /// <summary>
    /// Gets or sets the method by which the project is invoiced.
    /// </summary>
    [JsonProperty("bill_by")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public BillBy BillBy { get; set; }

    /// <summary>
    /// Gets or sets the rate for projects billed by <see cref="Models.BillBy.Project"/>.
    /// </summary>
    [JsonProperty("hourly_rate")]
    public decimal? HourlyRate { get; set; }

    /// <summary>
    /// Gets or sets the budget in hours for the project when budgeting by time.
    /// </summary>
    [JsonProperty("budget")]
    public decimal? Budget { get; set; }

    /// <summary>
    /// Gets or sets the method by which the project is budgeted.
    /// </summary>
    [JsonProperty("budget_by")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public BudgetBy BudgetBy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the budget resets every month.
    /// </summary>
    [JsonProperty("budget_is_monthly")]
    public bool? BudgetIsMonthly { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the project managers are notified when the project is over budget.
    /// </summary>
    [JsonProperty("notify_when_over_budget")]
    public bool? NotifyWhenOverBudget { get; set; }

    /// <summary>
    /// Gets or sets the percentage value used to trigger the over budget notification.
    /// </summary>
    [JsonProperty("over_budget_notification_percentage")]
    public decimal? OverBudgetNotificationPercentage { get; set; }

    /// <summary>
    /// Gets or sets the date of the last over budget notification.
    /// </summary>
    [JsonProperty("over_budget_notification_date")]
    public DateTime? OverBudgetNotificationDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to show project budget to all employees.
    /// </summary>
    [JsonProperty("show_budget_to_all")]
    public bool? ShowBudgetToAll { get; set; }

    /// <summary>
    /// Gets or sets the monetary budget for the project when budgeting by cost.
    /// </summary>
    [JsonProperty("cost_budget")]
    public decimal? CostBudget { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the budget of total project fees projects includes tracked expenses.
    /// </summary>
    [JsonProperty("cost_budget_include_expenses")]
    public bool? CostBudgetIncludeExpenses { get; set; }

    /// <summary>
    /// Gets or sets the amount you plan to invoice for the project. This is only used when the project is a fixed-fee project.
    /// </summary>
    [JsonProperty("fee")]
    public decimal? Fee { get; set; }

    /// <summary>
    /// Gets or sets the project notes.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the date the project was started.
    /// </summary>
    [JsonProperty("starts_on")]
    public DateTime? StartsOn { get; set; }

    /// <summary>
    /// Gets or sets the date the project will end.
    /// </summary>
    [JsonProperty("ends_on")]
    public DateTime? EndsOn { get; set; }
}