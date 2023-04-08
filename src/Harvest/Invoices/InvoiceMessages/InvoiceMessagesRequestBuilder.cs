namespace Harvest.Invoices.InvoiceMessages;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Harvest.Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage invoice messages for an invoice.
/// </summary>
public class InvoiceMessagesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceMessagesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoiceMessagesRequestBuilder(Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/invoices/{+invoiceid}/messages{?updated_since,page,per_page}", pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific invoice message.
    /// </summary>
    /// <param name="invoiceMessageId">The ID of the invoice message.</param>
    /// <returns>A builder for operations to manage a specific invoice message.</returns>
    public InvoiceMessageRequestBuilder this[long invoiceMessageId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "invoicemessageid", invoiceMessageId } };
            return new InvoiceMessageRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of invoice messages.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-messages/#list-all-messages-for-an-invoice
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of invoice messages.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<InvoiceMessagesResponse> GetAsync(
        Action<InvoiceMessagesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoiceMessagesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new invoice message.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-messages/#create-an-invoice-message
    /// </remarks>
    /// <param name="body">The invoice message to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created invoice message.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<InvoiceMessage> PostAsync(
        CreateInvoiceMessage body,
        Action<InvoiceMessagesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoiceMessage>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of invoice messages.
    /// </summary>
    public class InvoiceMessagesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<InvoiceMessagesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an invoice message.
    /// </summary>
    public class InvoiceMessagesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of invoice messages.
    /// </summary>
    public class InvoiceMessagesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the given date to return invoice messages that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}