namespace Harvest.Invoices.InvoiceMessages.Models;

using System.Collections.Generic;
using Harvest.Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of invoice messages.
/// </summary>
public class InvoiceMessagesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the invoice messages in the current page.
    /// </summary>
    [JsonProperty("invoice_messages")]
    public List<InvoiceMessage> InvoiceMessages { get; set; }
}