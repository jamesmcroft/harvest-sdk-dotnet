namespace Harvest.UserAssignments;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Harvest.Common.Requests;
using Harvest.Projects.UserAssignments.Models;

/// <summary>
/// Defines the builder for operations to manage the projects user assignments.
/// </summary>
public class UserAssignmentsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserAssignmentsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public UserAssignmentsRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/user_assignments{?user_id,is_active,updated_since,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a list of all project user assignments.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/projects-api/projects/user-assignments/#list-all-user-assignments
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of user assignments.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<UserAssignmentsResponse> GetAsync(
        Action<UserAssignmentsRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<UserAssignmentsResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of all project user assignments.
    /// </summary>
    public class UserAssignmentsRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<UserAssignmentsRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of all project user assignments.
    /// </summary>
    public class UserAssignmentsRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the ID of the user to retrieve assignments for.
        /// </summary>
        [QueryParameter("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to only return active assignments.
        /// </summary>
        [QueryParameter("is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the date to retrieve assignments that have been updated since.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}