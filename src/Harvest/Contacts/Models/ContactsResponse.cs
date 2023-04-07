namespace Harvest.Contacts.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines a response for a list of contacts.
/// </summary>
public class ContactsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the contacts in the current page.
    /// </summary>
    [JsonProperty("contacts")]
    public List<Contact> Contacts { get; set; }
}