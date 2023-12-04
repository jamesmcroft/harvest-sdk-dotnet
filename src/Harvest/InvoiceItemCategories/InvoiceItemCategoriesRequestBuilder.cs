namespace Harvest.InvoiceItemCategories;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage invoice item categories.
/// </summary>
public class InvoiceItemCategoriesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceItemCategoriesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoiceItemCategoriesRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/invoice_item_categories{?updated_since,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific invoice item category.
    /// </summary>
    /// <param name="invoiceItemCategoryId">The ID of the invoice item category.</param>
    /// <returns>A builder for operations to manage a specific invoice item category.</returns>
    public InvoiceItemCategoryRequestBuilder this[long invoiceItemCategoryId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters)
                {
                    { "invoiceitemcategoryid", invoiceItemCategoryId }
                };
            return new InvoiceItemCategoryRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of invoice item categories.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-item-categories/#list-all-invoice-item-categories.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of invoice item categories.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<InvoiceItemCategoriesResponse> GetAsync(
        Action<InvoiceItemCategoriesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoiceItemCategoriesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new invoice item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-item-categories/#create-an-invoice-item-category.
    /// </remarks>
    /// <param name="body">The invoice item category to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created invoice item category.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<InvoiceItemCategory> PostAsync(
        CreateInvoiceItemCategory body,
        Action<InvoiceItemCategoriesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoiceItemCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of invoice item categories.
    /// </summary>
    public class
        InvoiceItemCategoriesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<InvoiceItemCategoriesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an invoice item category.
    /// </summary>
    public class InvoiceItemCategoriesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of invoice item categories.
    /// </summary>
    public class InvoiceItemCategoriesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the given date to return invoice item categories that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}