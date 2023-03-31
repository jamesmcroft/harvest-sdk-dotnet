namespace Harvest.Reports.Expenses.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of expense reports.
/// </summary>
/// <typeparam name="TExpenseReport">The type of expense report.</typeparam>
public class ExpenseReportsResponse<TExpenseReport> : PaginatedEntriesResponse
    where TExpenseReport : ExpenseReportSummary
{
    /// <summary>
    /// Gets or sets the expense reports in the current page.
    /// </summary>
    [JsonProperty("results")]
    public List<TExpenseReport> Results { get; set; }
}