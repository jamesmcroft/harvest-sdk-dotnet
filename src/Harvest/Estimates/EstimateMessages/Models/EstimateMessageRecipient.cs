namespace Harvest.Estimates.EstimateMessages.Models;

using Newtonsoft.Json;

/// <summary>
/// Defines the detail for an estimate message recipient.
/// </summary>
public class EstimateMessageRecipient
{
    /// <summary>
    /// Gets or sets the name of the estimate message recipient.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email of the estimate message recipient.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }
}