namespace Harvest.Invoices.Models;

using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating a free-form invoice.
/// </summary>
public class CreateFreeFormInvoice : CreateInvoice
{
    /// <summary>
    /// Gets or sets the line items for the invoice.
    /// </summary>
    [JsonProperty("line_items")]
    public List<CreateFreeFormInvoiceLineItem> LineItems { get; set; }
}