namespace Harvest.Estimates.EstimateMessages.Models;

using System.Collections.Generic;
using Common.Responses;
using Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for an estimate message.
/// </summary>
public class EstimateMessage : Entry
{
    /// <summary>
    /// Gets or sets the name of the user that created the message.
    /// </summary>
    [JsonProperty("sent_by")]
    public string SentBy { get; set; }

    /// <summary>
    /// Gets or sets the email of the user that created the message.
    /// </summary>
    [JsonProperty("sent_by_email")]
    public string SentByEmail { get; set; }

    /// <summary>
    /// Gets or sets the name of the user that the message was sent from.
    /// </summary>
    [JsonProperty("sent_from")]
    public string SentFrom { get; set; }

    /// <summary>
    /// Gets or sets the email of the user that the message was sent from.
    /// </summary>
    [JsonProperty("sent_from_email")]
    public string SentFromEmail { get; set; }

    /// <summary>
    /// Gets or sets the recipients of the message.
    /// </summary>
    [JsonProperty("recipients")]
    public List<EstimateMessageRecipient> Recipients { get; set; }

    /// <summary>
    /// Gets or sets the subject of the message.
    /// </summary>
    [JsonProperty("subject")]
    public string Subject { get; set; }

    /// <summary>
    /// Gets or sets the body of the message.
    /// </summary>
    [JsonProperty("body")]
    public string Body { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to email a copy of the message to the current user.
    /// </summary>
    [JsonProperty("send_me_a_copy")]
    public bool? SendMeACopy { get; set; }

    /// <summary>
    /// Gets or sets the type of estimate event that occurred with the message.
    /// </summary>
    [JsonProperty("event_type")]
    [JsonConverter(typeof(EnumStringValueConverter))]
    public EstimateMessageEvent EventType { get; set; }
}