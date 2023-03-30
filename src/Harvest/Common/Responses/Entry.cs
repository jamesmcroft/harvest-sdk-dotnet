namespace Harvest.Common.Responses;

using System;
using Newtonsoft.Json;

/// <summary>
/// Defines the default response for an entry.
/// </summary>
public class Entry
{
    /// <summary>
    /// Gets or sets the unique identifier for the entry.
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }

    /// <summary>
    /// Gets or sets the date/time the entry was created.
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date/time the entry was last updated.
    /// </summary>
    [JsonProperty("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}