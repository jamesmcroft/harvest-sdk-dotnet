namespace Harvest.Users;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage users.
/// </summary>
public class UsersRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UsersRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UsersRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/users{?%24isactive,%24updatedsince,%24page,%24perpage}";
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
    /// Retrieves a list of users.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers and query parameters.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of users.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<UsersResponse> GetAsync(Action<UsersRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<UsersResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Builds the request to retrieve a list of users.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers and query parameters.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToGetRequestInformation(Action<UsersRequestBuilderGetRequestConfiguration> requestConfiguration = default)
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.GET,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");
        requestInfo.Headers.Add("Accept", "application/json");

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new UsersRequestBuilderGetRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddQueryParameters(requestConfig.QueryParameters);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of users.
    /// </summary>
    public class UsersRequestBuilderGetRequestConfiguration
    {
        /// <summary>
        /// Gets or sets the request headers.
        /// </summary>
        public Headers Headers { get; set; } = new();

        /// <summary>
        /// Gets or sets the query parameters for the request.
        /// </summary>
        public UsersRequestBuilderGetQueryParameters QueryParameters { get; set; } = new();
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of users.
    /// </summary>
    public class UsersRequestBuilderGetQueryParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether to only return active users or not.
        /// </summary>
        [QueryParameter("%24isactive")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the given date to return only users that have been updated since that date.
        /// </summary>
        [QueryParameter("%24updatedsince")]
        public DateTime? UpdatedSince { get; set; }

        /// <summary>
        /// Gets or sets the page number to use in pagination.
        /// </summary>
        [QueryParameter("%24page")]
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the number of records to return per page between 1 and 2000.
        /// </summary>
        [QueryParameter("%24perpage")]
        public int? PerPage { get; set; }
    }
}