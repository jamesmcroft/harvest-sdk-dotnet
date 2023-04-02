namespace Harvest.Common.Responses;

using System.Collections.Generic;
using Newtonsoft.Json;

/// <summary>
/// Defines the response for a list of paginated entries of a specified type.
/// </summary>
/// <typeparam name="TResult">The type of result.</typeparam>
public class ResultsResponse<TResult> : PaginatedEntriesResponse
    where TResult : class
{
    /// <summary>
    /// Gets or sets the results in the current page.
    /// </summary>
    [JsonProperty("results")]
    public List<TResult> Results { get; set; }
}