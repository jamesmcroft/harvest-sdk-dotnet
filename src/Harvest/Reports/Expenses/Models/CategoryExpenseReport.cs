namespace Harvest.Reports.Expenses.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a category's expense report.
/// </summary>
public class CategoryExpenseReport : ExpenseReportSummary
{
    /// <summary>
    /// Gets or sets the ID of the expense category for the expense report.
    /// </summary>
    [JsonProperty("expense_category_id")]
    public long? ExpenseCategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the expense category for the expense report.
    /// </summary>
    [JsonProperty("expense_category_name")]
    public string ExpenseCategoryName { get; set; }
}