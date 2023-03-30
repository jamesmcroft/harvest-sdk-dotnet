namespace Harvest.Common.Requests;

/// <summary>
/// Defines the parameters for paginated queries.
/// </summary>
public class PaginatedQueryParameters
{
    /// <summary>
    /// Gets or sets the page number to use in pagination.
    /// </summary>
    [QueryParameter("page")]
    public int? Page { get; set; }

    /// <summary>
    /// Gets or sets the number of records to return per page between 1 and 2000.
    /// </summary>
    [QueryParameter("per_page")]
    public int? PerPage { get; set; }
}