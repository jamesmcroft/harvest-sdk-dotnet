namespace Harvest.Company.Models;

using Common.Serialization;

/// <summary>
/// Defines how to display the currency symbol when formatting currency.
/// </summary>
public enum CurrencySymbolDisplay
{
    /// <summary>
    /// The currency symbol is not displayed.
    /// </summary>
    [EnumStringValue("symbol_none")]
    None,

    /// <summary>
    /// The currency symbol is displayed before the currency amount.
    /// </summary>
    [EnumStringValue("symbol_before")]
    Before,

    /// <summary>
    /// The currency symbol is displayed after the currency amount.
    /// </summary>
    [EnumStringValue("symbol_after")]
    After
}