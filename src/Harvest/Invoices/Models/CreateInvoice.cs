namespace Harvest.Invoices.Models;

using System;
using Harvest.Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an invoice.
/// </summary>
public abstract class CreateInvoice
{
    /// <summary>
    /// Gets or sets the ID of the client associated with the invoice.
    /// </summary>
    [JsonProperty("client_id")]
    public long ClientId { get; set; }

    /// <summary>
    /// Gets or sets the ID of the estimate associated with the invoice.
    /// </summary>
    [JsonProperty("estimate_id")]
    public long? EstimateId { get; set; }

    /// <summary>
    /// Gets or sets the number for the invoice.
    /// </summary>
    [JsonProperty("number")]
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the purchase order number for the invoice.
    /// </summary>
    [JsonProperty("purchase_order")]
    public string PurchaseOrder { get; set; }

    /// <summary>
    /// Gets or sets the percentage applied to the subtotal, including line items and discounts.
    /// </summary>
    [JsonProperty("tax")]
    public decimal? Tax { get; set; }

    /// <summary>
    /// Gets or sets the percentage applied to the subtotal, including line items and discounts.
    /// </summary>
    [JsonProperty("tax2")]
    public decimal? Tax2 { get; set; }

    /// <summary>
    /// Gets or sets the percentage subtracted from the subtotal.
    /// </summary>
    [JsonProperty("discount")]
    public decimal? Discount { get; set; }

    /// <summary>
    /// Gets or sets the subject of the invoice.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the additional notes included with the invoice.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the invoice.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the date the invoice was issued.
    /// </summary>
    [JsonProperty("issue_date")]
    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// Gets or sets the date the invoice is due.
    /// </summary>
    [JsonProperty("due_date")]
    public DateTime? DueDate { get; set; }

    /// <summary>
    /// Gets or sets the time frame in which the invoice should be paid.
    /// </summary>
    [JsonProperty("payment_term")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public InvoicePaymentTerm? PaymentTerm { get; set; }
}