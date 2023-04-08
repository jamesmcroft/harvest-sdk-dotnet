namespace Harvest.Invoices.Models;

using System;
using Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for importing expenses.
/// </summary>
public class ExpenseImport
{
    /// <summary>
    /// Gets or sets how to summarize the expenses per line item.
    /// </summary>
    [JsonProperty("summary_type")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public ExpenseImportSummaryType SummaryType { get; set; }

    /// <summary>
    /// Gets or sets the start date for included expenses.
    /// </summary>
    [JsonProperty("from")]
    public DateTime? From { get; set; }

    /// <summary>
    /// Gets or sets the end date for included expenses.
    /// </summary>
    [JsonProperty("to")]
    public DateTime? To { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to include a PDF containing an expense report with receipts.
    /// </summary>
    [JsonProperty("attach_receipts")]
    public bool? AttachReceipts { get; set; }
}