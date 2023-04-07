namespace Harvest.Contacts.Models;

using Clients.Models;
using Common.Responses;
using Newtonsoft.Json;

/// <summary>
/// Defines the detail for a contact.
/// </summary>
public class Contact : Entry
{
    /// <summary>
    /// Gets or sets the client associated with the contact.
    /// </summary>
    [JsonProperty("client")]
    public ClientSummary Client { get; set; }

    /// <summary>
    /// Gets or sets the title of the contact.
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the first name of the contact.
    /// </summary>
    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the contact.
    /// </summary>
    [JsonProperty("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// Gets or sets the email address of the contact.
    /// </summary>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the office phone number of the contact.
    /// </summary>
    [JsonProperty("phone_office")]
    public string PhoneOffice { get; set; }

    /// <summary>
    /// Gets or sets the mobile phone number of the contact.
    /// </summary>
    [JsonProperty("phone_mobile")]
    public string PhoneMobile { get; set; }

    /// <summary>
    /// Gets or sets the fax number of the contact.
    /// </summary>
    [JsonProperty("fax")]
    public string Fax { get; set; }
}