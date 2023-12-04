namespace Harvest.Clients;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage clients.
/// </summary>
public class ClientsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ClientsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ClientsRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/clients{?is_active,updated_since,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific client.
    /// </summary>
    /// <param name="clientId">The ID of the client.</param>
    /// <returns>A builder for operations to manage a specific client.</returns>
    public ClientRequestBuilder this[long clientId]
    {
        get
        {
            var urlTemplateParams = new Dictionary<string, object>(this.PathParameters) { { "clientid", clientId } };
            return new ClientRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of clients.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/clients-api/clients/clients/#list-all-clients.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of clients.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ClientsResponse> GetAsync(
        Action<ClientsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ClientsResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new client.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/clients-api/clients/clients/#create-a-client.
    /// </remarks>
    /// <param name="body">The client to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created client.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Client> PostAsync(
        CreateClient body,
        Action<ClientsRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Client>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of clients.
    /// </summary>
    public class
        ClientsRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<ClientsRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create a client.
    /// </summary>
    public class ClientsRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of clients.
    /// </summary>
    public class ClientsRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether to only return active clients or not.
        /// </summary>
        [QueryParameter("is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the given date to return only clients that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}