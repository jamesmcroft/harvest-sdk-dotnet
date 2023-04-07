namespace Harvest.Estimates.Models;

using EstimateItemCategories.Models;
using Newtonsoft.Json;

/// <summary>
/// Defines the request to create an estimate line item.
/// </summary>
public class CreateEstimateLineItem
{
    /// <summary>
    /// Gets or sets the name of an <see cref="EstimateItemCategory"/>.
    /// </summary>
    [JsonProperty("kind")]
    public string Kind { get; set; }

    /// <summary>
    /// Gets or sets the description of the line item.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the unit quantity of the item.
    /// </summary>
    [JsonProperty("quantity")]
    public int? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the individual price per unit.
    /// </summary>
    [JsonProperty("unit_price")]
    public decimal UnitPrice { get; set; }

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