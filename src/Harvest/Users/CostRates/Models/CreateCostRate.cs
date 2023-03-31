namespace Harvest.Users.CostRates.Models;

using Newtonsoft.Json;

using System;

/// <summary>
/// Defines the detail for creating a user's cost rate.
/// </summary>
public class CreateCostRate
{
    /// <summary>
    /// Gets or sets the amount of the user's cost rate.
    /// </summary>
    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the date the user's cost rate is effective.
    /// </summary>
    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }
}