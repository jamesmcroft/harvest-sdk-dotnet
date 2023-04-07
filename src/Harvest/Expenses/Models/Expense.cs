namespace Harvest.Expenses.Models;

using System;
using Clients.Models;
using Common.Responses;
using Harvest.ExpenseCategories.Models;
using Invoices.Models;
using Newtonsoft.Json;
using Projects.Models;
using Projects.UserAssignments.Models;
using Users.Models;

/// <summary>
/// Defines the detail for an expense.
/// </summary>
public class Expense : Entry
{
    /// <summary>
    /// Gets or sets the client associated with the expense.
    /// </summary>
    [JsonProperty("client")]
    public ClientSummary Client { get; set; }

    /// <summary>
    /// Gets or sets the project associated with the expense.
    /// </summary>
    [JsonProperty("project")]
    public ProjectSummary Project { get; set; }

    /// <summary>
    /// Gets or sets the expense category associated with the expense.
    /// </summary>
    [JsonProperty("expense_category")]
    public ExpenseCategory ExpenseCategory { get; set; }

    /// <summary>
    /// Gets or sets the user associated with the expense.
    /// </summary>
    [JsonProperty("user")]
    public UserSummary User { get; set; }

    /// <summary>
    /// Gets or sets the user assignment associated with the expense.
    /// </summary>
    [JsonProperty("user_assignment")]
    public UserAssignment UserAssignment { get; set; }

    /// <summary>
    /// Gets or sets the receipt for the expense.
    /// </summary>
    [JsonProperty("receipt")]
    public ExpenseReceipt Receipt { get; set; }

    /// <summary>
    /// Gets or sets the invoice for the expense.
    /// </summary>
    [JsonProperty("invoice")]
    public InvoiceSummary Invoice { get; set; }

    /// <summary>
    /// Gets or sets the notes used to describe the expense.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the quantity of units used to calculate the total cost of the expense.
    /// </summary>
    [JsonProperty("units")]
    public decimal? Units { get; set; }

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
    /// Gets or sets a value indicating whether the expense has been approved or closed.
    /// </summary>
    [JsonProperty("is_closed")]
    public bool? IsClosed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the expense has been invoiced, approved, or the project or person related to the expense is archived.
    /// </summary>
    [JsonProperty("is_locked")]
    public bool? IsLocked { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the expense has been marked as invoiced.
    /// </summary>
    [JsonProperty("is_billed")]
    public bool? IsBilled { get; set; }

    /// <summary>
    /// Gets or sets the reason the expense is locked.
    /// </summary>
    [JsonProperty("locked_reason")]
    public string LockedReason { get; set; }

    /// <summary>
    /// Gets or sets the date the expense occurred.
    /// </summary>
    [JsonProperty("spent_date")]
    public DateTime? SpentDate { get; set; }
}