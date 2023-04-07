namespace Harvest.Estimates.Models;

using System;
using System.Collections.Generic;
using Clients.Models;
using Common.Responses;
using Common.Serialization;
using Newtonsoft.Json;
using Users.Models;

/// <summary>
/// Defines the detail for an estimate.
/// </summary>
public class Estimate : Entry
{
    /// <summary>
    /// Gets or sets the client associated with the estimate.
    /// </summary>
    [JsonProperty("client")]
    public ClientSummary Client { get; set; }

    /// <summary>
    /// Gets or sets the line items for the estimate.
    /// </summary>
    [JsonProperty("line_items")]
    public List<EstimateLineItem> LineItems { get; set; }

    /// <summary>
    /// Gets or sets the creator of the estimate.
    /// </summary>
    [JsonProperty("creator")]
    public UserSummary Creator { get; set; }

    /// <summary>
    /// Gets or sets the value used to build a URL to the public web invoice for your client.
    /// </summary>
    [JsonProperty("client_key")]
    public string ClientKey { get; set; }

    /// <summary>
    /// Gets or sets the number for the estimate.
    /// </summary>
    [JsonProperty("number")]
    public string Number { get; set; }

    /// <summary>
    /// Gets or sets the purchase order number for the estimate.
    /// </summary>
    [JsonProperty("purchase_order")]
    public string PurchaseOrder { get; set; }

    /// <summary>
    /// Gets or sets the total amount for the estimate, including any discounts and taxes.
    /// </summary>
    [JsonProperty("amount")]
    public decimal? Amount { get; set; }

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
    /// Gets or sets the state of the estimate.
    /// </summary>
    [JsonProperty("state")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public EstimateState State { get; set; }

    /// <summary>
    /// Gets or sets the date the estimate was issued.
    /// </summary>
    [JsonProperty("issue_date")]
    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// Gets or sets the date the estimate was sent.
    /// </summary>
    [JsonProperty("sent_at")]
    public DateTime? SentAt { get; set; }

    /// <summary>
    /// Gets or sets the date the estimate was accepted.
    /// </summary>
    [JsonProperty("accepted_at")]
    public DateTime? AcceptedAt { get; set; }

    /// <summary>
    /// Gets or sets the date the estimate was declined.
    /// </summary>
    [JsonProperty("declined_at")]
    public DateTime? DeclinedAt { get; set; }
}