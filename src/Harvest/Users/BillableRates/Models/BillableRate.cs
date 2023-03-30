namespace Harvest.Users.BillableRates.Models;

using System;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail of a user's billable rate.
/// </summary>
public class BillableRate : Entry
{
    /// <summary>
    /// Gets or sets the amount of the user's billable rate.
    /// </summary>
    [JsonProperty("amount")]
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the date the user's billable rate is effective.
    /// </summary>
    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the date the user's billable rate is no longer effective.
    /// </summary>
    [JsonProperty("end_date")]
    public DateTime? EndDate { get; set; }
}