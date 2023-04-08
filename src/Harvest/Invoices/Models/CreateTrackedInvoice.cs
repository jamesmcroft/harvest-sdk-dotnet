namespace Harvest.Invoices.Models;

using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an invoice based on tracked time and expenses.
/// </summary>
public class CreateTrackedInvoice : CreateInvoice
{
    /// <summary>
    /// Gets or sets the line items to import for the invoice.
    /// </summary>
    [JsonProperty("line_items_import")]
    public List<CreateTrackedInvoiceLineItem> LineItemsImport { get; set; }
}