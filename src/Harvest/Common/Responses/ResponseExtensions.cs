namespace Harvest.Common.Responses;

/// <summary>
/// Defines a collection of extension methods for response values.
/// </summary>
internal static class ResponseExtensions
{
    /// <summary>
    /// Attempts to get a value from a <see cref="System.Collections.Specialized.NameValueCollection"/> and returns a value indicating whether the value was found.
    /// </summary>
    /// <param name="collection">The collection to get a value from.</param>
    /// <param name="key">The key of the value to retrieve.</param>
    /// <param name="value">The value retrieved from the collection.</param>
    /// <returns><see langword="true"/> if the value was found; <see langword="false"/> otherwise.</returns>
    public static bool TryGetValue(
        this System.Collections.Specialized.NameValueCollection collection,
        string key,
        out string value)
    {
        value = collection[key];
        return !string.IsNullOrEmpty(value);
    }
}