namespace Harvest.Users.BillableRates;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a billable rate for a user.
/// </summary>
public class BillableRateRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BillableRateRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public BillableRateRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/users/{+userid}/billable_rates/{+billablerateid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves a billable rate for a user.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/users-api/users/billable-rates/#retrieve-a-billable-rate
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The billable rate details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<BillableRate> GetAsync(
        Action<BillableRateRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<BillableRate>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get a billable rate for a user.
    /// </summary>
    public class BillableRateRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }
}