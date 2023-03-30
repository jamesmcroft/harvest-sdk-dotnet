namespace Harvest.Users.BillableRates.Models;

using Newtonsoft.Json;

using System;

/// <summary>
/// Defines the detail for creating a user's billable rate.
/// </summary>
public class CreateBillableRate
{
    /// <summary>
    /// Gets or sets the amount of the user's billable rate.
    /// </summary>
    [JsonProperty("amount")]
    public decimal Amount { get; set; }

    /// <summary>
    /// Gets or sets the date the user's billable rate is effective.
    /// </summary>
    [JsonProperty("start_date")]
    public DateTime? StartDate { get; set; }
}