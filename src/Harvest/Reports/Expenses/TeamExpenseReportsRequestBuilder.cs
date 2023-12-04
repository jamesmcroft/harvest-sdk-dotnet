namespace Harvest.Reports.Expenses;

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
/// Defines the builder for operations to manage team expense reports.
/// </summary>
public class TeamExpenseReportsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TeamExpenseReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public TeamExpenseReportsRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/reports/expenses/team{?from,to,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a list of team expense reports.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/reports-api/reports/expense-reports/#expense-team-report.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of team expense reports.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ResultsResponse<TeamExpenseReport>> GetAsync(
        Action<TeamExpenseReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ResultsResponse<TeamExpenseReport>>(
            requestInfo,
            cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of team expense reports.
    /// </summary>
    public class TeamExpenseReportsRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<TeamExpenseReportsRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of team expense reports.
    /// </summary>
    public class TeamExpenseReportsRequestBuilderGetQueryParameters : ReportsQueryParameters
    {
    }
}