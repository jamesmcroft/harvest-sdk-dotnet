namespace Harvest.InvoiceItemCategories.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request for updating an invoice item category.
/// </summary>
public class UpdateInvoiceItemCategory
{
    /// <summary>
    /// Gets or sets the name of the invoice item category.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}