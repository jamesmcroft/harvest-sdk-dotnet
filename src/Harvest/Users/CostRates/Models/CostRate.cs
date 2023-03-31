namespace Harvest.Users.CostRates.Models;

using System;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a user's cost rate.
/// </summary>
public class CostRate : Entry
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

    /// <summary>
    /// Gets or sets the date the user's cost rate is no longer effective.
    /// </summary>
    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }
}