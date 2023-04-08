namespace Harvest.Invoices.Models;

using Harvest.Common.Serialization;

/// <summary>
/// Defines the states of an invoice.
/// </summary>
public enum InvoiceState
{
    /// <summary>
    /// The invoice is a draft.
    /// </summary>
    [EnumStringValue("draft")] Draft,

    /// <summary>
    /// The invoice is open.
    /// </summary>
    [EnumStringValue("open")] Open,

    /// <summary>
    /// The invoice is paid.
    /// </summary>
    [EnumStringValue("paid")] Paid,

    /// <summary>
    /// The invoice is closed.
    /// </summary>
    [EnumStringValue("closed")] Closed
}