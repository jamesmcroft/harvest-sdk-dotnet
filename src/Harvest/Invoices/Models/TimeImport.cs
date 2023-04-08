namespace Harvest.Invoices.Models;

using System;
using Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for importing time entries.
/// </summary>
public class TimeImport
{
    /// <summary>
    /// Gets or sets how to summarize the time entries per line item.
    /// </summary>
    [JsonProperty("summary_type")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public TimeImportSummaryType SummaryType { get; set; }

    /// <summary>
    /// Gets or sets the start date for included time entries.
    /// </summary>
    [JsonProperty("from")]
    public DateTime? From { get; set; }

    /// <summary>
    /// Gets or sets the end date for included time entries.
    /// </summary>
    [JsonProperty("to")]
    public DateTime? To { get; set; }
}