namespace Harvest.Invoices.Models;

using InvoiceItemCategories.Models;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an invoice line item.
/// </summary>
public class CreateFreeFormInvoiceLineItem
{
    /// <summary>
    /// Gets or sets the ID of the project associated with the line item.
    /// </summary>
    [JsonProperty("project_id")]
    public long? ProjectId { get; set; }

    /// <summary>
    /// Gets or sets the name of an <see cref="InvoiceItemCategory"/>.
    /// </summary>
    [JsonProperty("kind")]
    public string Kind { get; set; }

    /// <summary>
    /// Gets or sets the text description of the line item.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the unit quantity of the item.
    /// </summary>
    [JsonProperty("quantity")]
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the individual price per unit.
    /// </summary>
    [JsonProperty("unit_price")]
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the estimates Tax percentage applies to this line item.
    /// </summary>
    [JsonProperty("taxed")]
    public bool? Taxed { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the estimates Tax2 percentage applies to this line item.
    /// </summary>
    [JsonProperty("taxed2")]
    public bool? Taxed2 { get; set; }
}