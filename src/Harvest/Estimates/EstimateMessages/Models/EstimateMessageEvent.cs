namespace Harvest.Estimates.EstimateMessages.Models;

using Common.Serialization;

/// <summary>
/// Defines the event for an estimate message.
/// </summary>
public enum EstimateMessageEvent
{
    /// <summary>
    /// The estimate message event is send.
    /// </summary>
    [EnumStringValue("send")] Send,

    /// <summary>
    /// The estimate message event is accept.
    /// </summary>
    [EnumStringValue("accept")] Accept,

    /// <summary>
    /// The estimate message event is decline.
    /// </summary>
    [EnumStringValue("decline")] Decline,

    /// <summary>
    /// The estimate message event is re-open.
    /// </summary>
    [EnumStringValue("re-open")] Reopen,

    /// <summary>
    /// The estimate message event is view.
    /// </summary>
    [EnumStringValue("view")] View,

    /// <summary>
    /// The estimate message event is invoice.
    /// </summary>
    [EnumStringValue("invoice")] Invoice
}