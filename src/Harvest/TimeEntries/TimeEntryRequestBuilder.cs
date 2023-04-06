namespace Harvest.TimeEntries;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific time entry.
/// </summary>
public class TimeEntryRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeEntryRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public TimeEntryRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/time_entries/{+timeentryid}";
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
    /// Retrieves a time entry.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/#retrieve-a-time-entry
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The time entry details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<TimeEntry> GetAsync(
        Action<TimeEntryRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<TimeEntry>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates a time entry.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/#update-a-time-entry
    /// </remarks>
    /// <param name="body">The time entry details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated time entry details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<TimeEntry> PatchAsync(
        UpdateTimeEntry body,
        Action<TimeEntryRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<TimeEntry>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes a time entry.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/#delete-a-time-entry
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<TimeEntryRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Restarts the time tracking for a time entry.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/#restart-a-stopped-time-entry
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The restarted time entry details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<TimeEntry> RestartAsync(
        Action<TimeEntryRequestBuilderRestartRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToRestartRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<TimeEntry>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Stops the time tracking for a time entry.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/#stop-a-running-time-entry
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The stopped time entry details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<TimeEntry> StopAsync(
        Action<TimeEntryRequestBuilderStopRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToStopRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<TimeEntry>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Builds the request to retrieve a time entry.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToGetRequestInformation(
        Action<TimeEntryRequestBuilderGetRequestConfiguration> requestConfiguration)
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

        var requestConfig = new TimeEntryRequestBuilderGetRequestConfiguration();
        requestConfiguration(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);
        return requestInfo;
    }

    /// <summary>
    /// Builds the request to update a time entry.
    /// </summary>
    /// <param name="body">The request body.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToPatchRequestInformation(
        UpdateTimeEntry body,
        Action<TimeEntryRequestBuilderPatchRequestConfiguration> requestConfiguration)
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

        var requestConfig = new TimeEntryRequestBuilderPatchRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Builds the request to delete a time entry.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToDeleteRequestInformation(
        Action<TimeEntryRequestBuilderDeleteRequestConfiguration> requestConfiguration)
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

        var requestConfig = new TimeEntryRequestBuilderDeleteRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Builds the request to restart a time entry.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToRestartRequestInformation(
        Action<TimeEntryRequestBuilderRestartRequestConfiguration> requestConfiguration)
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.PATCH,
            UrlTemplate = $"{this.UrlTemplate}/restart",
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");
        requestInfo.Headers.Add("Accept", "application/json");

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new TimeEntryRequestBuilderRestartRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Builds the request to stop a time entry.
    /// </summary>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <returns>A request information object.</returns>
    public RequestInformation ToStopRequestInformation(
        Action<TimeEntryRequestBuilderStopRequestConfiguration> requestConfiguration)
    {
        var requestInfo = new RequestInformation
        {
            HttpMethod = Method.PATCH,
            UrlTemplate = $"{this.UrlTemplate}/stop",
            PathParameters = this.PathParameters,
        };

        requestInfo.Headers.Add("User-Agent", "HarvestDotnetSdk");
        requestInfo.Headers.Add("Accept", "application/json");

        if (requestConfiguration == null)
        {
            return requestInfo;
        }

        var requestConfig = new TimeEntryRequestBuilderStopRequestConfiguration();
        requestConfiguration.Invoke(requestConfig);
        requestInfo.AddHeaders(requestConfig.Headers);

        return requestInfo;
    }

    /// <summary>
    /// Defines the configuration for the request to get a time entry.
    /// </summary>
    public class TimeEntryRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update a time entry.
    /// </summary>
    public class TimeEntryRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete a time entry.
    /// </summary>
    public class TimeEntryRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to restart a time entry.
    /// </summary>
    public class TimeEntryRequestBuilderRestartRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to stop a time entry.
    /// </summary>
    public class TimeEntryRequestBuilderStopRequestConfiguration : RequestConfiguration
    {
    }
}