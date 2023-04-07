namespace Harvest.Estimates.Models;

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines the request to create an estimate.
/// </summary>
public class CreateEstimate
{
    /// <summary>
    /// Gets or sets the ID of the client associated with the estimate.
    /// </summary>
    [JsonProperty("client_id")]
    public long ClientId { get; set; }

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
    /// Gets or sets the date the estimate was issued.
    /// </summary>
    [JsonProperty("issue_date")]
    public DateTime? IssueDate { get; set; }

    /// <summary>
    /// Gets or sets the line items associated with the estimate.
    /// </summary>
    [JsonProperty("line_items")]
    public List<CreateEstimateLineItem> LineItems { get; set; }
}