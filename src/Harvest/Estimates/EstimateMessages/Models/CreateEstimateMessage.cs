namespace Harvest.Estimates.EstimateMessages.Models;

using System.Collections.Generic;
using Harvest.Common.Serialization;
using Newtonsoft.Json;

/// <summary>
/// Defines the request for creating an estimate message.
/// </summary>
public class CreateEstimateMessage
{
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