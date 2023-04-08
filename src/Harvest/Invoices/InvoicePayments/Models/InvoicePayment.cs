namespace Harvest.Invoices.InvoicePayments.Models;

using System;
using Harvest.Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for an invoice payment.
/// </summary>
public class InvoicePayment : Entry
{
    /// <summary>
    /// Gets or sets the amount of the payment.
    /// </summary>
    [JsonProperty("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the date and time the payment was made.
    /// </summary>
    [JsonProperty("paid_at")]
    public DateTime? PaidAt { get; set; }

    /// <summary>
    /// Gets or sets the date the payment was made.
    /// </summary>
    [JsonProperty("paid_date")]
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the person who recorded the payment.
    /// </summary>
    [JsonProperty("recorded_by")]
    public string RecordedBy { get; set; }

    /// <summary>
    /// Gets or sets the email of the person who recorded the payment.
    /// </summary>
    [JsonProperty("recorded_by_email")]
    public string RecordedByEmail { get; set; }

    /// <summary>
    /// Gets or sets any notes associated with the payment.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets either the card authorization or PayPal transaction ID.
    /// </summary>
    [JsonProperty("transaction_id")]
    public string TransactionId { get; set; }

    /// <summary>
    /// Gets or sets the payment gateway details used to process the payment.
    /// </summary>
    [JsonProperty("payment_gateway")]
    public PaymentGateway PaymentGateway { get; set; }
}