namespace Harvest.Invoices.InvoiceMessages.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail for a new invoice message.
/// </summary>
public class NewInvoiceMessage
{
    /// <summary>
    /// Gets or sets the ID of the invoice.
    /// </summary>
    [JsonProperty("invoice_id")]
    public long InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the subject of the message.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the body of the message.
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a reminder message.
    /// </summary>
    [JsonProperty("reminder")]
    public bool? Reminder { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a thank you message.
    /// </summary>
    [JsonProperty("thank_you")]
    public bool? ThankYou { get; set; }
}