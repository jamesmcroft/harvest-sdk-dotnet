namespace Harvest.EstimateItemCategories.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an estimate item category.
/// </summary>
public class CreateEstimateItemCategory
{
    /// <summary>
    /// Gets or sets the name of the estimate item category.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}