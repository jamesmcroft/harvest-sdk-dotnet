namespace Harvest.Invoices.Models;

using System;
using System.Collections.Generic;
using Clients.Models;
using Estimates.Models;
using Harvest.Common.Serialization;
using Newtonsoft.Json;
using Users.Models;

/// <summary>
/// Defines the detail for an invoice.
/// </summary>
public class Invoice : InvoiceSummary
{
    /// <summary>
    /// Gets or sets the client of the invoice.
    /// </summary>
    [JsonProperty("client")]
    public ClientSummary Client { get; set; }

    /// <summary>
    /// Gets or sets the line items for the invoice.
    /// </summary>
    [JsonProperty("line_items")]
    public List<InvoiceLineItem> LineItems { get; set; }

    /// <summary>
    /// Gets or sets the estimate associated with the invoice.
    /// </summary>
    [JsonProperty("estimate")]
    public EstimateSummary Estimate { get; set; }

    /// <summary>
    /// Gets or sets the creator of the invoice.
    /// </summary>
    [JsonProperty("creator")]
    public UserSummary Creator { get; set; }

    /// <summary>
    /// Gets or sets the value used to build a URL to the public web invoice for your client.
    /// </summary>
    [JsonProperty("client_key")]
    public string ClientKey { get; set; }

    /// <summary>
    /// Gets or sets the purchase order number for the invoice.
    /// </summary>
    [JsonProperty("purchase_order")]
    public string PurchaseOrder { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the estimate, including any discounts and taxes.
    /// </summary>
    [JsonProperty("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the total amount due at this time for this invoice.
    /// </summary>
    [JsonProperty("due_amount")]
    public decimal? DueAmount { get; set; }

    /// <summary>
    /// Gets or sets the percentage applied to the subtotal, including line items and discounts.
    /// </summary>
    [JsonProperty("tax")]
    public decimal? Tax { get; set; }

    /// <summary>
    /// Gets or sets the first amount of tax included, calculated from <see cref="Tax"/>.
    /// </summary>
    [JsonProperty("tax_amount")]
    public decimal? TaxAmount { get; set; }

    /// <summary>
    /// Gets or sets the percentage applied to the subtotal, including line items and discounts.
    /// </summary>
    [JsonProperty("tax2")]
    public decimal? Tax2 { get; set; }

    /// <summary>
    /// Gets or sets the amount calculated from <see cref="Tax2"/>.
    /// </summary>
    [JsonProperty("tax2_amount")]
    public decimal? Tax2Amount { get; set; }

    /// <summary>
    /// Gets or sets the percentage subtracted from the subtotal.
    /// </summary>
    [JsonProperty("discount")]
    public decimal? Discount { get; set; }

    /// <summary>
    /// Gets or sets the amount calculated from the <see cref="Discount"/>.
    /// </summary>
    [JsonProperty("discount_amount")]
    public decimal? DiscountAmount { get; set; }

    /// <summary>
    /// Gets or sets the subject of the estimate.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the additional notes included with the estimate.
    /// </summary>
    [JsonProperty("notes")]
    public string Notes { get; set; }

    /// <summary>
    /// Gets or sets the currency code associated with the estimate.
    /// </summary>
    [JsonProperty("currency")]
    public string Currency { get; set; }

    /// <summary>
    /// Gets or sets the state of the invoice.
    /// </summary>
    [JsonProperty("state")]
    [JsonConverter(typeof(EnumStringValueConverter))]

    public InvoiceState State { get; set; }

    /// <summary>
    /// Gets or sets the start of the period during which time entries were added to this invoice.
    /// </summary>
    [JsonProperty("period_start")]
    public DateTime? PeriodState { get; set; }

    /// <summary>
    /// Gets or sets the end of the period during which time entries were added to this invoice.
    /// </summary>
    [JsonProperty("period_end")]
    public DateTime? PeriodEnd { get; set; }

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
    public InvoicePaymentTerm PaymentTerm { get; set; }

    /// <summary>
    /// Gets or sets the date the invoice was sent.
    /// </summary>
    [JsonProperty("sent_at")]
    public DateTime? SentAt { get; set; }

    /// <summary>
    /// Gets or sets the date the invoice was paid.
    /// </summary>
    [JsonProperty("paid_at")]
    public DateTime? PaidAt { get; set; }

    /// <summary>
    /// Gets or sets the date the invoice was paid.
    /// </summary>
    [JsonProperty("paid_date")]
    public DateTime? PaidDate { get; set; }

    /// <summary>
    /// Gets or sets the date the invoice was closed.
    /// </summary>
    [JsonProperty("closed_at")]
    public DateTime? ClosedAt { get; set; }

    /// <summary>
    /// Gets or sets the ID of the associated recurring invoice.
    /// </summary>
    [JsonProperty("recurring_invoice_id")]
    public long? RecurringInvoiceId { get; set; }
}