namespace Harvest.Users.Teammates;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage the teammates for the user.
/// </summary>
public class TeammatesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TeammatesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public TeammatesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/users/{+userid}/teammates{?page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a list of teammates for the user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/teammates/#list-all-assigned-teammates-for-a-specific-user.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of teammates.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<TeammatesResponse> GetAsync(
        Action<TeammatesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<TeammatesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Retrieves a list of teammates for the user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/teammates/#update-a-users-assigned-teammates.
    /// </remarks>
    /// <param name="body">The request body.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of teammates.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<TeammatesResponse> PatchAsync(
        UserTeammates body,
        Action<TeammatesRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<TeammatesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of teammates for the user.
    /// </summary>
    public class TeammatesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<TeammatesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update a list of teammates for the user.
    /// </summary>
    public class TeammatesRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of teammates for the user.
    /// </summary>
    public class TeammatesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
    }
}