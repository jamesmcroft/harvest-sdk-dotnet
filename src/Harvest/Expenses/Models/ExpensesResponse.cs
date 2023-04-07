namespace Harvest.Expenses.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of expenses.
/// </summary>
public class ExpensesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the expenses in the current page.
    /// </summary>
    [JsonProperty("expenses")]
    public List<Expense> Expenses { get; set; }
}