namespace Harvest.Users.BillableRates;

using System.Collections.Generic;

using System;
using Common.Requests;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using Models;

/// <summary>
/// Defines the builder for operations to manage the billable rates of the user.
/// </summary>
public class BillableRatesRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BillableRatesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public BillableRatesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/users/{+userid}/billable_rates{?page,per_page}";
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
    /// Gets the builder for operations to manage a specific billable rate of the user.
    /// </summary>
    /// <param name="billableRateId">The ID of the billable rate.</param>
    /// <returns>A builder for operations to manage a specific billable rate of the user.</returns>
    public BillableRateRequestBuilder this[long billableRateId]
    {
        get
        {
            var urlTemplateParams = new Dictionary<string, object>(this.PathParameters) { { "billablerateid", billableRateId } };
            return new BillableRateRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of billable rates for the user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/billable-rates/#list-all-billable-rates-for-a-specific-user
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of billable rates.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<BillableRatesResponse> GetAsync(
        Action<BillableRatesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<BillableRatesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new billable rate for the user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/billable-rates/#create-a-billable-rate
    /// </remarks>
    /// <param name="body">The billable rate to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created billable rate.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<BillableRate> PostAsync(
        CreateBillableRate body,
        Action<BillableRatesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<BillableRate>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Builds the request to retrieve a list of billable rates for the user.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToGetRequestInformation(
        Action<BillableRatesRequestBuilderGetRequestConfiguration> requestConfiguration)
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

        var requestConfig = new BillableRatesRequestBuilderGetRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddQueryParameters(requestConfig.QueryParameters);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Builds the request to create a new billable rate for the user.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public RequestInformation ToPostRequestInformation(
        CreateBillableRate body,
        Action<BillableRatesRequestBuilderPostRequestConfiguration> requestConfiguration)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.POST, UrlTemplate = this.UrlTemplate, PathParameters = this.PathParameters
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");
        requestInfo.Headers.Add("Accept", "application/json");

        requestInfo.SetJsonContent(body);

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new BillableRatesRequestBuilderPostRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of billable rates for the user.
    /// </summary>
    public class BillableRatesRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
        /// <summary>
        /// Gets or sets the query parameters for the request.
        /// </summary>
        public BillableRatesRequestBuilderGetQueryParameters QueryParameters { get; set; } = new();
    }

    /// <summary>
    /// Defines the configuration for the request to create a new billable rate for the user.
    /// </summary>
    public class BillableRatesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of billable rates for the user.
    /// </summary>
    public class BillableRatesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
    }
}