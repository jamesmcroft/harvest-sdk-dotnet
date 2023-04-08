namespace Harvest.Invoices.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of invoices.
/// </summary>
public class InvoicesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the invoices in the current page.
    /// </summary>
    [JsonProperty("invoices")]
    public List<Invoice> Invoices { get; set; }
}