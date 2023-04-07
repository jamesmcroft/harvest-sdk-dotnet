namespace Harvest.Company.Models;

using Common.Serialization;

/// <summary>
/// Defines the type of plan a company can be on.
/// </summary>
public enum PlanType
{
    /// <summary>
    /// The company is on a trial plan.
    /// </summary>
    [EnumStringValue("trial")] Trial,

    /// <summary>
    /// The company is on a free plan.
    /// </summary>
    [EnumStringValue("free")] Free,

    /// <summary>
    /// The company is on a simple paid plan.
    /// </summary>
    [EnumStringValue("simple-v4")] SimpleV4
}