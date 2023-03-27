namespace Harvest.Common.Requests;

/// <summary>
/// Represents the HTTP method used by a request.
/// </summary>
public enum Method
{
    /// <summary>
    /// The HTTP GET method.
    /// </summary>
    GET,

    /// <summary>
    /// The HTTP POST method.
    /// </summary>
    POST,

    /// <summary>
    /// The HTTP PATCH method.
    /// </summary>
    PATCH,

    /// <summary>
    /// The HTTP DELETE method.
    /// </summary>
    DELETE,

    /// <summary>
    /// The HTTP PUT method.
    /// </summary>
    PUT,
}