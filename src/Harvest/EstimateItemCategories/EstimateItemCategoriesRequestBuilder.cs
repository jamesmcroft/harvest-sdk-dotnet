namespace Harvest.EstimateItemCategories;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage estimate item categories.
/// </summary>
public class EstimateItemCategoriesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EstimateItemCategoriesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public EstimateItemCategoriesRequestBuilder(Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/estimate_item_categories{?updated_since,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific estimate item category.
    /// </summary>
    /// <param name="estimateItemCategoryId">The ID of the estimate item category.</param>
    /// <returns>A builder for operations to manage a specific estimate item category.</returns>
    public EstimateItemCategoryRequestBuilder this[long estimateItemCategoryId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters)
                {
                    { "estimateitemcategory", estimateItemCategoryId }
                };
            return new EstimateItemCategoryRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of estimate item categories.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-item-categories/#list-all-estimate-item-categories
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of estimate item categories.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<EstimateItemCategoriesResponse> GetAsync(
        Action<EstimateItemCategoriesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimateItemCategoriesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new estimate item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/estimates-api/estimates/estimate-item-categories/#create-an-estimate-item-category
    /// </remarks>
    /// <param name="body">The estimate item category to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created estimate item category.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<EstimateItemCategory> PostAsync(
        CreateEstimateItemCategory body,
        Action<EstimateItemCategoriesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<EstimateItemCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of estimate item categories.
    /// </summary>
    public class
        EstimateItemCategoriesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<EstimateItemCategoriesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an estimate item category.
    /// </summary>
    public class EstimateItemCategoriesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of estimate item categories.
    /// </summary>
    public class EstimateItemCategoriesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the given date to return estimate item categories that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}