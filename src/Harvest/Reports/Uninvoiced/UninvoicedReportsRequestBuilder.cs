namespace Harvest.Reports.Uninvoiced;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Harvest.Common.Responses;
using Harvest.Reports.Models;
using Models;

/// <summary>
/// Defines the builder for operations to manage uninvoiced reports.
/// </summary>
public class UninvoicedReportsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UninvoicedReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UninvoicedReportsRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/reports/uninvoiced{?from,to,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a list of uninvoiced reports.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/reports-api/reports/uninvoiced-report/#uninvoiced-report.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of uninvoiced reports.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ResultsResponse<UninvoicedReport>> GetAsync(
        Action<UninvoicedReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ResultsResponse<UninvoicedReport>>(
            requestInfo,
            cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of uninvoiced reports.
    /// </summary>
    public class UninvoicedReportsRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<UninvoicedReportsRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of uninvoiced reports.
    /// </summary>
    public class UninvoicedReportsRequestBuilderGetQueryParameters : ReportsQueryParameters
    {
    }
}