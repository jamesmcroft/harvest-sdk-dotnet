namespace Harvest.Invoices.InvoiceMessages.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail for a message recipient.
/// </summary>
public class InvoiceMessageRecipient
{
    /// <summary>
    /// Gets or sets the name of the message recipient.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email of the message recipient.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
}