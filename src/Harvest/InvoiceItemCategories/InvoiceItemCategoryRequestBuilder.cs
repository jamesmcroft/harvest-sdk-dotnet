namespace Harvest.InvoiceItemCategories;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific invoice item category.
/// </summary>
public class InvoiceItemCategoryRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceItemCategoryRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoiceItemCategoryRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/invoice_item_categories/{+invoiceitemcategoryid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves an invoice item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-item-categories/#retrieve-an-invoice-item-category.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The invoice item category details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<InvoiceItemCategory> GetAsync(
        Action<InvoiceItemCategoryRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoiceItemCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates an invoice item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-item-categories/#update-an-invoice-item-category.
    /// </remarks>
    /// <param name="body">The invoice item category details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated invoice item category details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<InvoiceItemCategory> PatchAsync(
        UpdateInvoiceItemCategory body,
        Action<InvoiceItemCategoryRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoiceItemCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes an invoice item category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-item-categories/#delete-an-invoice-item-category.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<InvoiceItemCategoryRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get an invoice item category.
    /// </summary>
    public class InvoiceItemCategoryRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update an invoice item category.
    /// </summary>
    public class InvoiceItemCategoryRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete an invoice item category.
    /// </summary>
    public class InvoiceItemCategoryRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}