namespace Harvest.Invoices;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage invoices.
/// </summary>
public class InvoicesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvoicesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public InvoicesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/invoices{?client_id,project_id,updated_since,from,to,state,page,per_page}", pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific invoice.
    /// </summary>
    /// <param name="invoiceId">The ID of the invoice.</param>
    /// <returns>A builder for operations to manage a specific invoice.</returns>
    public InvoiceRequestBuilder this[long invoiceId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "invoiceid", invoiceId } };
            return new InvoiceRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of invoices.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoices/#list-all-invoices
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of invoices.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<InvoicesResponse> GetAsync(
        Action<InvoicesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<InvoicesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new invoice.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/invoices-api/invoices/invoices
    /// </remarks>
    /// <param name="body">The invoice to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created invoice.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Invoice> PostAsync(
        CreateInvoice body,
        Action<InvoicesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Invoice>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of invoices.
    /// </summary>
    public class InvoicesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<InvoicesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an invoice.
    /// </summary>
    public class InvoicesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of invoices.
    /// </summary>
    public class InvoicesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the ID of the client to return invoices belonging to that client.
        /// </summary>
        [QueryParameter("client_id")]
        public long? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the project to return invoices belonging to that project.
        /// </summary>
        [QueryParameter("project_id")]
        public long? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the given date to return invoices that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }

        /// <summary>
        /// Gets or sets the given date to return invoices that have been created since that date.
        /// </summary>
        [QueryParameter("from")]
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the given date to return invoices that have been created before that date.
        /// </summary>
        [QueryParameter("to")]
        public DateTime? To { get; set; }

        /// <summary>
        /// Gets or sets the state of the invoices to return.
        /// </summary>
        [QueryParameter("state")]
        public InvoiceState? State { get; set; }
    }
}