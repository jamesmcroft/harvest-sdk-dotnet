namespace Harvest.Authentication;

/// <summary>
/// Defines the scopes available for Harvest API authentication.
/// </summary>
public static class Scopes
{
    /// <summary>
    /// Access to all accounts.
    /// </summary>
    public const string All = "all";

    /// <summary>
    /// Access to all Forecast accounts.
    /// </summary>
    public const string ForecastAll = "forecast:all";

    /// <summary>
    /// Access to all Harvest accounts.
    /// </summary>
    public const string HarvestAll = "harvest:all";

    /// <summary>
    /// Access to a Forecast account by ID.
    /// </summary>
    /// <param name="accountId">The Forecast account ID.</param>
    /// <returns>The scope for accessing a Forecast account by ID.</returns>
    public static string ForecastAccount(string accountId)
    {
        return $"forecast:{accountId}";
    }

    /// <summary>
    /// Access to a Harvest account by ID.
    /// </summary>
    /// <param name="accountId">The Harvest account ID.</param>
    /// <returns>The scope for accessing a Harvest account by ID.</returns>
    public static string HarvestAccount(string accountId)
    {
        return $"harvest:{accountId}";
    }
}