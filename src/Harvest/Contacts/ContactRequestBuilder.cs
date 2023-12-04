namespace Harvest.Contacts;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific contact.
/// </summary>
public class ContactRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ContactRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/contacts/{+contactid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a contact.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/clients-api/clients/contacts/#retrieve-a-contact.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The contact details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<Contact> GetAsync(
        Action<ContactRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<Contact>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates a contact.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/clients-api/clients/contacts/#update-a-contact.
    /// </remarks>
    /// <param name="body">The contact details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated contact details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Contact> PatchAsync(
        UpdateContact body,
        Action<ContactRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Contact>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes a contact.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/clients-api/clients/contacts/#delete-a-contact.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<ContactRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get a contact.
    /// </summary>
    public class ContactRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update a contact.
    /// </summary>
    public class ContactRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete a contact.
    /// </summary>
    public class ContactRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}