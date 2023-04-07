namespace Harvest.ExpenseCategories.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of expense categories.
/// </summary>
public class ExpenseCategoriesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the expense categories in the current page.
    /// </summary>
    [JsonProperty("expense_categories")]
    public List<ExpenseCategory> ExpenseCategories { get; set; }
}