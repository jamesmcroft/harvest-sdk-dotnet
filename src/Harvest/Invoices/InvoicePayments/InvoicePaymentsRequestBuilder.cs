namespace Harvest.Invoices.InvoicePayments;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Harvest.Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage invoice payments for an invoice.
/// </summary>
public class InvoicePaymentsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoicePaymentsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoicePaymentsRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base(
            "{+baseurl}/invoices/{+invoiceid}/payments{?updated_since,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific invoice payment.
    /// </summary>
    /// <param name="invoicePaymentId">The ID of the invoice payment.</param>
    /// <returns>A builder for operations to manage a specific invoice payment.</returns>
    public InvoicePaymentRequestBuilder this[long invoicePaymentId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "invoicepaymentid", invoicePaymentId } };
            return new InvoicePaymentRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of invoice payments.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-payments/#list-all-payments-for-an-invoice.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of invoice payments.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<InvoicePaymentsResponse> GetAsync(
        Action<InvoicePaymentsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoicePaymentsResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new invoice payment.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoice-payments/#create-an-invoice-payment.
    /// </remarks>
    /// <param name="body">The invoice payment to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created invoice payment.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<InvoicePayment> PostAsync(
        CreateInvoicePayment body,
        Action<InvoicePaymentsRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoicePayment>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of invoice payments.
    /// </summary>
    public class InvoicePaymentsRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<InvoicePaymentsRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an invoice payment.
    /// </summary>
    public class InvoicePaymentsRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of invoice payments.
    /// </summary>
    public class InvoicePaymentsRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the given date to return invoice payments that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}