namespace Harvest.Company.Models;

using Common.Serialization;

/// <summary>
/// Defines the formats used to display time in harvest.
/// </summary>
public enum TimeFormat
{
    /// <summary>
    /// The time format is a decimal.
    /// </summary>
    [EnumStringValue("decimal")]
    Decimal,

    /// <summary>
    /// The time format is hours and minutes.
    /// </summary>
    [EnumStringValue("hours_minutes")]
    HoursMinutes,
}