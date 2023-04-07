namespace Harvest.Estimates.Models;

using System.Collections.Generic;
using Common.Responses;

/// <summary>
/// Defines the response for a list of estimates.
/// </summary>
public class EstimatesResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the estimates in the current page.
    /// </summary>
    public List<Estimate> Estimates { get; set; }
}