namespace Harvest.Users;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BillableRates;
using Common.Requests;
using Models;
using Teammates;

/// <summary>
/// Defines the builder for operations to manage a specific user.
/// </summary>
public class UserRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UserRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/users/{+userid}";
        this.PathParameters = new Dictionary<string, object>(pathParameters);
        this.RequestAdapter = requestAdapter;
    }

    /// <summary>
    /// Gets the builder for operations to manage the teammates for the user.
    /// </summary>
    public TeammatesRequestBuilder Teammates => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage the billable rates for the user.
    /// </summary>
    public BillableRatesRequestBuilder BillableRates => new(this.PathParameters, this.RequestAdapter);

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
    public async Task<User> GetAsync(
        Action<UserRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<User>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates a user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#update-a-user
    /// </remarks>
    /// <param name="body">The user details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated user details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<User> PatchAsync(
        User body,
        Action<UserRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<User>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes a user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#delete-a-user
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<UserRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Builds the request to retrieve a user.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToGetRequestInformation(
        Action<UserRequestBuilderGetRequestConfiguration> requestConfiguration)
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

        var requestConfig = new UserRequestBuilderGetRequestConfiguration();
        requestConfiguration(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);
        return requestInfo;
    }

    /// <summary>
    /// Builds the request to update a user.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToPatchRequestInformation(
        User body,
        Action<UserRequestBuilderPatchRequestConfiguration> requestConfiguration)
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.PATCH,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");
        requestInfo.Headers.Add("Accept", "application/json");

        requestInfo.SetJsonContent(body);

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new UserRequestBuilderPatchRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Builds the request to delete a user.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToDeleteRequestInformation(
        Action<UserRequestBuilderDeleteRequestConfiguration> requestConfiguration)
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.DELETE,
            UrlTemplate = this.UrlTemplate,
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new UserRequestBuilderDeleteRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Defines the configuration for the request to get a user.
    /// </summary>
    public class UserRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update a user.
    /// </summary>
    public class UserRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete a user.
    /// </summary>
    public class UserRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}