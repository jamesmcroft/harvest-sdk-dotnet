namespace Harvest.Invoices.Models;

using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating a line item for an invoice based on tracked time and expenses.
/// </summary>
public class CreateTrackedInvoiceLineItem
{
    /// <summary>
    /// Gets or sets the list of client's project IDs you'd like to include time/expenses from.
    /// </summary>
    [JsonProperty("project_ids")]
    public List<long> ProjectIds { get; set; }

    /// <summary>
    /// Gets or sets the time import.
    /// </summary>
    [JsonProperty("time")]
    public TimeImport Time { get; set; }

    /// <summary>
    /// Gets or sets the expenses import.
    /// </summary>
    [JsonProperty("expenses")]
    public ExpenseImport Expenses { get; set; }
}