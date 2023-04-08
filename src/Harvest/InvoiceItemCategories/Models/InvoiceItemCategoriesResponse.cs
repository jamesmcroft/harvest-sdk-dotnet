namespace Harvest.InvoiceItemCategories.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of invoice item categories.
/// </summary>
public class InvoiceItemCategoriesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the invoice item categories in the current page.
    /// </summary>
    [JsonProperty("invoice_item_categories")]
    public List<InvoiceItemCategory> InvoiceItemCategories { get; set; }
}