namespace Harvest.Expenses.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail for an expense receipt.
/// </summary>
public class ExpenseReceipt
{
    /// <summary>
    /// Gets or sets the URL for the receipt.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// Gets or sets the name of the file for the receipt.
    /// </summary>
    [JsonProperty("file_name")]
    public string FileName { get; set; }

    /// <summary>
    /// Gets or sets the size of the file for the receipt.
    /// </summary>
    [JsonProperty("file_size")]
    public int? FileSize { get; set; }

    /// <summary>
    /// Gets or sets the content type of the file for the receipt.
    /// </summary>
    [JsonProperty("content_type")]
    public string ContentType { get; set; }
}