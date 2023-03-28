namespace Harvest.Users;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific user.
/// </summary>
public class UserEntryRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserEntryRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UserEntryRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/users/{+userid}";
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
    /// Retrieves a user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#retrieve-a-user
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The user details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<User> GetAsync(Action<UserEntryRequestBuilderGetRequestConfiguration> requestConfiguration = default, CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<User>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Builds the request to retrieve a user.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToGetRequestInformation(Action<UserEntryRequestBuilderGetRequestConfiguration> requestConfiguration)
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

        var requestConfig = new UserEntryRequestBuilderGetRequestConfiguration();
        requestConfiguration(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);
        return requestInfo;
    }

    /// <summary>
    /// Defines the configuration for the request to get a user.
    /// </summary>
    public class UserEntryRequestBuilderGetRequestConfiguration : BaseRequestConfiguration
    {
    }
}

