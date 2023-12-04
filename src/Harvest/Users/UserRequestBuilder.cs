namespace Harvest.Users;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BillableRates;
using Common.Requests;
using CostRates;
using Models;
using ProjectAssignments;
using Teammates;

/// <summary>
/// Defines the builder for operations to manage a specific user.
/// </summary>
public class UserRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UserRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/users/{+userid}", pathParameters, requestAdapter)
    {
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
    /// Gets the builder for operations to manage the cost rates for the user.
    /// </summary>
    public CostRatesRequestBuilder CostRates => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage the project assignments for the user.
    /// </summary>
    public ProjectAssignmentsRequestBuilder ProjectAssignments => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Retrieves a user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#retrieve-a-user.
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
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#update-a-user.
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
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#delete-a-user.
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