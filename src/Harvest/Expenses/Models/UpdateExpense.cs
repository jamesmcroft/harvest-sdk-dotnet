namespace Harvest.Expenses.Models;

using System;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for updating an expense.
/// </summary>
public class UpdateExpense
{
    /// <summary>
    /// Gets or sets the ID of the project associated with the expense.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the expense category associated with the expense.
    /// </summary>
    [JsonProperty("expense_category_id")]
    public long? ExpenseCategoryId { get; set; }

    /// <summary>
    /// Gets or sets the date the expense occurred.
    /// </summary>
    [JsonProperty("spent_date")]
    public DateTime? SpentDate { get; set; }

    /// <summary>
    /// Gets or sets the notes used to describe the expense.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the quantity of units used to calculate the total cost of the expense.
    /// </summary>
    [JsonProperty("units")]
    public int? Units { get; set; }

    /// <summary>
    /// Gets or sets the total cost of the expense.
    /// </summary>
    [JsonProperty("total_cost")]
    public decimal? TotalCost { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the expense is billable.
    /// </summary>
    [JsonProperty("billable")]
    public bool? Billable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the receipt should be deleted.
    /// </summary>
    [JsonProperty("delete_receipt")]
    public bool? DeleteReceipt { get; set; }
}