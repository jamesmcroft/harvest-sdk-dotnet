namespace Harvest.Invoices.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the summary detail for an invoice.
/// </summary>
public class InvoiceSummary : Entry
{
    /// <summary>
    /// Gets or sets the number of the invoice.
    /// </summary>
    [JsonProperty("number")]
    public string Number { get; set; }
}