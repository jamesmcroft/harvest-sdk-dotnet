namespace Harvest.Invoices.InvoiceMessages.Models;

using System.Collections.Generic;
using Harvest.Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an invoice message.
/// </summary>
public class CreateInvoiceMessage
{
    /// <summary>
    /// Gets or sets the recipients of the message.
    /// </summary>
    [JsonProperty("recipients")]
    public List<InvoiceMessageRecipient> Recipients { get; set; }

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
    /// Gets or sets a value indicating whether to include a link to the client invoice in the message body.
    /// </summary>
    [JsonProperty("include_link_to_client_invoice")]
    public bool? IncludeLinkToClientInvoice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to attach the invoice PDF to the message email.
    /// </summary>
    [JsonProperty("attach_pdf")]
    public bool? AttachPdf { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to email a copy of the message to the current user.
    /// </summary>
    [JsonProperty("send_me_a_copy")]
    public bool? SendMeACopy { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a thank you message.
    /// </summary>
    [JsonProperty("thank_you")]
    public bool? ThankYou { get; set; }

    /// <summary>
    /// Gets or sets the type of invoice event that occurred with the message.
    /// </summary>
    [JsonProperty("event_type")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public InvoiceMessageEvent EventType { get; set; }
}