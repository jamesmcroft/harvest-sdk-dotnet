namespace Harvest.Common.Responses;

using Newtonsoft.Json;

/// <summary>
/// Defines the base response for paginated entries.
/// </summary>
public class BaseEntryPaginationResponse
{
    /// <summary>
    /// Gets or sets the total number of entries per page.
    /// </summary>
    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages.
    /// </summary>
    [JsonProperty("total_pages")]
    public int TotalPages { get; set; }

    /// <summary>
    /// Gets or sets the total number of entries.
    /// </summary>
    [JsonProperty("total_entries")]
    public int TotalEntries { get; set; }

    /// <summary>
    /// Gets or sets the current page of entries.
    /// </summary>
    [JsonProperty("page")]
    public int Page { get; set; }
}