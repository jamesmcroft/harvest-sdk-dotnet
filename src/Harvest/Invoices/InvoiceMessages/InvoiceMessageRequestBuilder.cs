namespace Harvest.Invoices.InvoiceMessages;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Harvest.Common.Requests;

/// <summary>
/// Defines the builder for operations to manage a specific invoice message.
/// </summary>
public class InvoiceMessageRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceMessageRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoiceMessageRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/invoices/{+invoiceid}/messages/{+invoicemessageid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Deletes an invoice message.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-messages/#delete-an-invoice-message.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<InvoiceMessageRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Define the configuration for the request to delete an invoice message.
    /// </summary>
    public class InvoiceMessageRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}