namespace Harvest.Common.Responses;

internal static class ResponseExtensions
{
    public static bool TryGetValue(this System.Collections.Specialized.NameValueCollection collection, string key, out string value)
    {
        value = collection[key];
        return !string.IsNullOrEmpty(value);
    }
}