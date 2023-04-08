namespace Harvest.Estimates.EstimateMessages.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of estimate messages.
/// </summary>
public class EstimateMessagesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the estimate messages in the current page.
    /// </summary>
    [JsonProperty("estimate_messages")]
    public List<EstimateMessage> EstimateMessages { get; set; }
}