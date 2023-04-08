namespace Harvest.Invoices.InvoicePayments.Models;

using System;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an invoice payment.
/// </summary>
public class CreateInvoicePayment
{
    /// <summary>
    /// Gets or set the amount of the payment.
    /// </summary>
    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the date and time the payment was made.
    /// </summary>
    /// <remarks>
    /// Pass either <see cref="PaidAt"/> or <see cref="PaidDate"/>, but not both.
    /// </remarks>
    [JsonProperty("paid_at")]
    public DateTime? PaidAt { get; set; }

    /// <summary>
    /// Gets or sets the date the payment was made.
    /// </summary>
    /// <remarks>
    /// Pass either <see cref="PaidAt"/> or <see cref="PaidDate"/>, but not both.
    /// </remarks>
    [JsonProperty("paid_date")]
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// Gets or sets any notes to be associated with the payment.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }
}