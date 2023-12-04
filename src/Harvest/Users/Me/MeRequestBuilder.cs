namespace Harvest.Users.Me;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage the current authenticated user.
/// </summary>
public class MeRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MeRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public MeRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/users/me", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage the project assignments for the current authenticated user.
    /// </summary>
    public ProjectAssignmentsRequestBuilder ProjectAssignments => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Retrieves the current authenticated user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#retrieve-the-currently-authenticated-user.
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
    /// Defines the configuration for the request to retrieve the current authenticated user.
    /// </summary>
    public class UserRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }
}