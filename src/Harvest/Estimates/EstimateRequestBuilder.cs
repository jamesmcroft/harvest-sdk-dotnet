namespace Harvest.Estimates;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using EstimateMessages;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific client.
/// </summary>
public class EstimateRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EstimateRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public EstimateRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/estimates/{+estimateid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage estimate messages for this estimate.
    /// </summary>
    public EstimateMessagesRequestBuilder Messages => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Retrieves an estimate.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimates/#retrieve-an-estimate.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The estimate details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<Estimate> GetAsync(
        Action<EstimateRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<Estimate>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates an estimate.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimates/#update-an-estimate.
    /// </remarks>
    /// <param name="body">The estimate details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated estimate details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Estimate> PatchAsync(
        UpdateEstimate body,
        Action<EstimateRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Estimate>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes an estimate.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimates/#delete-an-estimate.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<EstimateRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get an estimate.
    /// </summary>
    public class EstimateRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update an estimate.
    /// </summary>
    public class EstimateRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete an estimate.
    /// </summary>
    public class EstimateRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}