namespace Harvest.Estimates;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage estimates.
/// </summary>
public class EstimatesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EstimatesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public EstimatesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base(
            "{+baseurl}/estimates{?client_id,updated_since,from,to,state,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific estimates.
    /// </summary>
    /// <param name="estimateId">The ID of the estimate.</param>
    /// <returns>A builder for operations to manage a specific estimate.</returns>
    public EstimateRequestBuilder this[long estimateId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "estimateid", estimateId } };
            return new EstimateRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of estimates.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimates/#list-all-estimates.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of estimates.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<EstimatesResponse> GetAsync(
        Action<EstimatesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimatesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new estimate.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimates/#create-an-estimate.
    /// </remarks>
    /// <param name="body">The estimate to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created estimate.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Estimate> PostAsync(
        CreateEstimate body,
        Action<EstimatesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Estimate>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of estimates.
    /// </summary>
    public class EstimatesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<EstimatesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an estimate.
    /// </summary>
    public class EstimatesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of estimates.
    /// </summary>
    public class EstimatesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the ID of the client to return estimates belonging to that client.
        /// </summary>
        [QueryParameter("client_id")]
        public long? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the given date to return estimates that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }

        /// <summary>
        /// Gets or sets the given date to return estimates that have been created since that date.
        /// </summary>
        [QueryParameter("from")]
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the given date to return estimates that have been created before that date.
        /// </summary>
        [QueryParameter("to")]
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets or sets the state of the estimates to return.
        /// </summary>
        [QueryParameter("state")]
        public EstimateState? State { get; set; }
    }
}