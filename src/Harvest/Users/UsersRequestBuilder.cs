namespace Harvest.Users;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Harvest.Users.Me;
using Models;

/// <summary>
/// Defines the builder for operations to manage users.
/// </summary>
public class UsersRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UsersRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UsersRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/users{?is_active,updated_since,page,per_page}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage the current user.
    /// </summary>
    public MeRequestBuilder Me => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage a specific user.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>A builder for operations to manage a specific user.</returns>
    public UserRequestBuilder this[long userId]
    {
        get
        {
            var urlTemplateParams = new Dictionary<string, object>(this.PathParameters) { { "userid", userId } };
            return new UserRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of users.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#list-all-users.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of users.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<UsersResponse> GetAsync(
        Action<UsersRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<UsersResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/users/#create-a-user.
    /// </remarks>
    /// <param name="body">The user to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created user.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<User> PostAsync(
        CreateUser body,
        Action<UsersRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<User>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of users.
    /// </summary>
    public class UsersRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<UsersRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create a user.
    /// </summary>
    public class UsersRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of users.
    /// </summary>
    public class UsersRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether to only return active users or not.
        /// </summary>
        [QueryParameter("is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the given date to return only users that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}