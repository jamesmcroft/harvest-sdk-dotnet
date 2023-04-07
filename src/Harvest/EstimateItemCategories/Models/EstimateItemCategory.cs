namespace Harvest.EstimateItemCategories.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for an estimate item category.
/// </summary>
public class EstimateItemCategory : Entry
{
    /// <summary>
    /// Gets or sets the name of the estimate item category.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}