namespace Harvest.Estimates.Models;

using Common.Serialization;

/// <summary>
/// Defines the states of an estimate.
/// </summary>
public enum EstimateState
{
    /// <summary>
    /// The estimate is a draft.
    /// </summary>
    [EnumStringValue("draft")] Draft,

    /// <summary>
    /// The estimate has been sent.
    /// </summary>
    [EnumStringValue("sent")] Sent,

    /// <summary>
    /// The estimate has been accepted.
    /// </summary>
    [EnumStringValue("accepted")] Accepted,

    /// <summary>
    /// The estimate has been declined.
    /// </summary>
    [EnumStringValue("declined")] Declined
}