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
/// Defines the builder for operations to manage projects expense reports.
/// </summary>
public class ProjectsExpenseReportsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectsExpenseReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ProjectsExpenseReportsRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/reports/expenses/projects{?from,to,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a list of projects expense reports.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/reports-api/reports/expense-reports/#projects-report.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of projects expense reports.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ResultsResponse<ProjectExpenseReport>> GetAsync(
        Action<ProjectsExpenseReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ResultsResponse<ProjectExpenseReport>>(
            requestInfo,
            cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of projects expense reports.
    /// </summary>
    public class ProjectsExpenseReportsRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<ProjectsExpenseReportsRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of projects expense reports.
    /// </summary>
    public class ProjectsExpenseReportsRequestBuilderGetQueryParameters : ReportsQueryParameters
    {
    }
}