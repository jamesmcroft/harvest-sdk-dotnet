namespace Harvest.InvoiceItemCategories.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an invoice item category.
/// </summary>
public class CreateInvoiceItemCategory
{
    /// <summary>
    /// Gets or sets the name of the invoice item category.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
}