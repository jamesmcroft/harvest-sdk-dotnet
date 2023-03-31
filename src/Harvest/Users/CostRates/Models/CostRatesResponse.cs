namespace Harvest.Users.CostRates.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of user's cost rates.
/// </summary>
public class CostRatesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the user's cost rates in the current page.
    /// </summary>
    [JsonProperty("cost_rates")]
    public List<CostRate> CostRates { get; set; }
}