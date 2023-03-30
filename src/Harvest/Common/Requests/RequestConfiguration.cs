namespace Harvest.Common.Requests;

/// <summary>
/// Defines the base configuration for a request.
/// </summary>
public abstract class RequestConfiguration
{
    /// <summary>
    /// Gets or sets the request headers.
    /// </summary>
    public Headers Headers { get; set; } = new();
}