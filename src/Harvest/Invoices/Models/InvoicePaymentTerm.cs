namespace Harvest.Invoices.Models;

using Common.Serialization;

/// <summary>
/// Defines the payment terms for an invoice.
/// </summary>
public enum InvoicePaymentTerm
{
    /// <summary>
    /// The payment is due upon receipt.
    /// </summary>
    [EnumStringValue("upon receipt")]
    UponReceipt,

    /// <summary>
    /// The payment is due in 15 days of the invoice date.
    /// </summary>
    [EnumStringValue("net 15")]
    Net15,

    /// <summary>
    /// The payment is due in 30 days of the invoice date.
    /// </summary>
    [EnumStringValue("net 30")]
    Net30,

    /// <summary>
    /// The payment is due in 45 days of the invoice date.
    /// </summary>
    [EnumStringValue("net 45")]
    Net45,

    /// <summary>
    /// The payment is due in 60 days of the invoice date.
    /// </summary>
    [EnumStringValue("net 60")]
    Net60,

    /// <summary>
    /// The payment is due on a custom date.
    /// </summary>
    [EnumStringValue("custom")]
    Custom
}