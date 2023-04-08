namespace Harvest.Invoices.InvoicePayments.Models;

using System.Collections.Generic;
using Harvest.Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of invoice payments.
/// </summary>
public class InvoicePaymentsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the invoice payments in the current page.
    /// </summary>
    [JsonProperty("invoice_payments")]
    public List<InvoicePayment> InvoicePayments { get; set; }
}