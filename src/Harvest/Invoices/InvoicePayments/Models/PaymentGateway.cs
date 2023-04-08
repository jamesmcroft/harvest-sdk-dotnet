namespace Harvest.Invoices.InvoicePayments.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the details for the payment gateway used to process the payment.
/// </summary>
public class PaymentGateway
{
    /// <summary>
    /// Gets or sets the ID of the payment gateway.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the payment gateway.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}