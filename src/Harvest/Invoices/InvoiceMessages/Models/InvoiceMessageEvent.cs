namespace Harvest.Invoices.InvoiceMessages.Models;

using Harvest.Common.Serialization;

/// <summary>
/// Defines the event for an invoice message.
/// </summary>
public enum InvoiceMessageEvent
{
    /// <summary>
    /// The message event is send.
    /// </summary>
    [EnumStringValue("send")] Send,

    /// <summary>
    /// The message event is close.
    /// </summary>
    [EnumStringValue("close")] Close,

    /// <summary>
    /// The message event is draft.
    /// </summary>
    [EnumStringValue("draft")] Draft,

    /// <summary>
    /// The message event is re-open.
    /// </summary>
    [EnumStringValue("re-open")] Reopen,

    /// <summary>
    /// The message event is view.
    /// </summary>
    [EnumStringValue("view")] View,
}