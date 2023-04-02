namespace Harvest.Reports.ProjectBudget;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Harvest.Common.Responses;
using Models;

/// <summary>
/// Defines the builder for operations to manage project budget reports.
/// </summary>
public class ProjectBudgetReportsRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ProjectBudgetReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ProjectBudgetReportsRequestBuilder(Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/reports/project_budget{?is_active,page,per_page}";
        this.PathParameters = new Dictionary<string, object>(pathParameters);
        this.RequestAdapter = requestAdapter;
    }

    /// <summary>
    /// Gets the path parameters to use to build the request URL.
    /// </summary>
    private Dictionary<string, object> PathParameters { get; }

    /// <summary>
    /// Gets the request adapter to use to execute the requests.
    /// </summary>
    private HarvestRequestAdapter RequestAdapter { get; }

    /// <summary>
    /// Gets the URL template to use to build the request URL.
    /// </summary>
    private string UrlTemplate { get; }

    /// <summary>
    /// Retrieves a list of project budget reports.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/reports-api/reports/project-budget-report/#project-budget-report
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of project budget reports.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ResultsResponse<ProjectBudgetReport>> GetAsync(
        Action<ProjectBudgetReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ResultsResponse<ProjectBudgetReport>>(requestInfo,
            cancellationToken);
    }

    /// <summary>
    /// Builds the request to retrieve a list of project budget reports.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToGetRequestInformation(
        Action<ProjectBudgetReportsRequestBuilderGetRequestConfiguration> requestConfiguration = default)
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.GET, UrlTemplate = this.UrlTemplate, PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");
        requestInfo.Headers.Add("Accept", "application/json");

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new ProjectBudgetReportsRequestBuilderGetRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddQueryParameters(requestConfig.QueryParameters);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of project budget reports.
    /// </summary>
    public class ProjectBudgetReportsRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
        /// <summary>
        /// Gets or sets the query parameters for the request.
        /// </summary>
        public ProjectBudgetReportsRequestBuilderGetQueryParameters QueryParameters { get; set; } = new();
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of project budget reports.
    /// </summary>
    public class ProjectBudgetReportsRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether to only return active projects.
        /// </summary>
        [QueryParameter("is_active")]
        public bool? IsActive { get; set; }
    }
}