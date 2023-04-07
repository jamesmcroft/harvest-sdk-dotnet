namespace Harvest.Company.Models;

using Common.Serialization;

/// <summary>
/// Defines the day of the week that a week starts on.
/// </summary>
public enum WeekStartDay
{
    /// <summary>
    /// The week starts on Saturday.
    /// </summary>
    [EnumStringValue("Saturday")]
    Saturday,

    /// <summary>
    /// The week starts on Sunday.
    /// </summary>
    [EnumStringValue("Sunday")]
    Sunday,

    /// <summary>
    /// The week starts on Monday.
    /// </summary>
    [EnumStringValue("Monday")]
    Monday,
}