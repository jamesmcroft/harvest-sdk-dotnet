namespace Harvest.EstimateItemCategories;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific estimate item category.
/// </summary>
public class EstimateItemCategoryRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EstimateItemCategoryRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public EstimateItemCategoryRequestBuilder(Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/estimate_item_categories/{+estimateitemcategory}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves an estimate item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-item-categories/#retrieve-an-estimate-item-category
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The estimate item category details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<EstimateItemCategory> GetAsync(
        Action<EstimateItemCategoryRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimateItemCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates an estimate item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-item-categories/#update-an-estimate-item-category
    /// </remarks>
    /// <param name="body">The estimate item category details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated estimate item category details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<EstimateItemCategory> PatchAsync(
        UpdateEstimateItemCategory body,
        Action<EstimateItemCategoryRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimateItemCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes an estimate item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-item-categories/#delete-an-estimate-item-category
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<EstimateItemCategoryRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get an estimate item category.
    /// </summary>
    public class EstimateItemCategoryRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update an estimate item category.
    /// </summary>
    public class EstimateItemCategoryRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete an estimate item category.
    /// </summary>
    public class EstimateItemCategoryRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}