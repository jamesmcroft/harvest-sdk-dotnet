namespace Harvest.EstimateItemCategories.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of estimate item categories.
/// </summary>
public class EstimateItemCategoriesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the estimate item categories in the current page.
    /// </summary>
    [JsonProperty("estimate_item_categories")]
    public List<EstimateItemCategory> EstimateItemCategories { get; set; }
}