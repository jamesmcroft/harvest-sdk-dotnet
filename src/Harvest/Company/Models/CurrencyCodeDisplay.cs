namespace Harvest.Company.Models;

using Common.Serialization;

/// <summary>
/// Defines how to display the currency code when formatting currency.
/// </summary>
public enum CurrencyCodeDisplay
{
    /// <summary>
    /// The currency code is not displayed.
    /// </summary>
    [EnumStringValue("iso_code_none")]
    None,

    /// <summary>
    /// The currency code is displayed before the currency amount.
    /// </summary>
    [EnumStringValue("iso_code_before")]
    Before,

    /// <summary>
    /// The currency code is displayed after the currency amount.
    /// </summary>
    [EnumStringValue("iso_code_after")]
    After
}