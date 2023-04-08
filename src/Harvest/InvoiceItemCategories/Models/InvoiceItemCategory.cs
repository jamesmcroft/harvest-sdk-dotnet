namespace Harvest.InvoiceItemCategories.Models;

using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for an invoice item category.
/// </summary>
public class InvoiceItemCategory : Entry
{
    /// <summary>
    /// Gets or sets the name of the invoice item category.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this invoice item category is used for billable hours when generating an invoice.
    /// </summary>
    [JsonProperty("use_as_service")]
    public bool? UseAsService { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this invoice item category is used for expenses when generating an invoice.
    /// </summary>
    [JsonProperty("use_as_expense")]
    public bool? UseAsExpense { get; set; }
}