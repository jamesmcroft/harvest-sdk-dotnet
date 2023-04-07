namespace Harvest.Common.Requests;

/// <summary>
/// Defines the base configuration for a queryable request.
/// </summary>
public class QueryableRequestConfiguration<TQuery> : QueryableRequestConfiguration
    where TQuery : QueryParameters, new()
{
    /// <summary>
    /// Gets or sets the query parameters for the request.
    /// </summary>
    public TQuery QueryParameters { get; set; } = new();

    /// <inheritdoc />
    public override QueryParameters GetQueryParameters()
    {
        return this.QueryParameters;
    }
}

/// <summary>
/// Defines the base configuration for a queryable request.
/// </summary>
public abstract class QueryableRequestConfiguration : RequestConfiguration
{
    /// <summary>
    /// Retrieves the query parameters for the request.
    /// </summary>
    /// <returns>The query parameters for the request.</returns>
    public abstract QueryParameters GetQueryParameters();
}