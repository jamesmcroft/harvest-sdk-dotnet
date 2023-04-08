namespace Harvest.Invoices;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using InvoiceMessages;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific invoice.
/// </summary>
public class InvoiceRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoiceRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/invoices/{+invoiceid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage the messages of a specific invoice.
    /// </summary>
    public InvoiceMessagesRequestBuilder Messages => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Retrieves an invoice.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoices/#retrieve-an-invoice
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The invoice details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<Invoice> GetAsync(
        Action<InvoiceRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<Invoice>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates an invoice.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoices/#update-an-invoice
    /// </remarks>
    /// <param name="body">The invoice details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated invoice details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Invoice> PatchAsync(
        UpdateInvoice body,
        Action<InvoiceRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Invoice>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes an invoice.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoices/#delete-an-invoice
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<InvoiceRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get an invoice.
    /// </summary>
    public class InvoiceRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update an invoice.
    /// </summary>
    public class InvoiceRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete an invoice.
    /// </summary>
    public class InvoiceRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}