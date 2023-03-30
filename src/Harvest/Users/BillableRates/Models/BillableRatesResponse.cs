namespace Harvest.Users.BillableRates.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of user's billable rates.
/// </summary>
public class BillableRatesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the user's billable rates in the current page.
    /// </summary>
    [JsonProperty("billable_rates")]
    public List<BillableRate> BillableRates { get; set; }
}