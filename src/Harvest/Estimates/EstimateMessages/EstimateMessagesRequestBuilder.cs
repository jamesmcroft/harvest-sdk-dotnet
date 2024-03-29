namespace Harvest.Estimates.EstimateMessages;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage estimate messages for an estimate.
/// </summary>
public class EstimateMessagesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EstimateMessagesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public EstimateMessagesRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base(
            "{+baseurl}/estimates/{+estimateid}/messages{?updated_since,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific estimate message.
    /// </summary>
    /// <param name="estimateMessageId">The ID of the estimate message.</param>
    /// <returns>A builder for operations to manage a specific estimate message.</returns>
    public EstimateMessageRequestBuilder this[long estimateMessageId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "estimatemessageid", estimateMessageId } };
            return new EstimateMessageRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of estimate messages.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-messages/#list-all-messages-for-an-estimate.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of estimate messages.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<EstimateMessagesResponse> GetAsync(
        Action<EstimateMessagesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimateMessagesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new estimate message.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-messages/#create-an-estimate-message.
    /// </remarks>
    /// <param name="body">The estimate message to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created estimate message.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<EstimateMessage> PostAsync(
        CreateEstimateMessage body,
        Action<EstimateMessagesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimateMessage>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of estimate messages.
    /// </summary>
    public class EstimateMessagesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<EstimateMessagesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an estimate message.
    /// </summary>
    public class EstimateMessagesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of estimate messages.
    /// </summary>
    public class EstimateMessagesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the given date to return estimate messages that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}