namespace Harvest.Clients.Models;

using System.Collections.Generic;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines a response for a list of clients.
/// </summary>
public class ClientsResponse : PaginatedEntriesResponse
{
    /// <summary>
    /// Gets or sets the clients in the current page.
    /// </summary>
    [JsonProperty("clients")]
    public List<Client> Clients { get; set; }
}