namespace Harvest.Invoices.Models;

using InvoiceItemCategories.Models;
using Newtonsoft.Json;
using Projects.Models;

/// <summary>
/// Defines the detail for an invoice line item.
/// </summary>
public class InvoiceLineItem
{
    /// <summary>
    /// Gets or sets the unique identifier for the line item.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the project associated with the line item.
    /// </summary>
    [JsonProperty("project")]
    public ProjectSummary Project { get; set; }

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
    /// Gets or sets the line item subtotal.
    /// </summary>
    [JsonProperty("amount")]
    public decimal? Amount { get; set; }

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