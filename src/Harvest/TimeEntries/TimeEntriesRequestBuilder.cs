namespace Harvest.TimeEntries;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage time entries.
/// </summary>
public class TimeEntriesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeEntriesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public TimeEntriesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base(
            "{+baseurl}/time_entries{?user_id,client_id,project_id,task_id,external_reference_id,is_billed,is_running,updated_since,from,to,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific time entry.
    /// </summary>
    /// <param name="timeEntryId">The ID of the time entry.</param>
    /// <returns>A builder for operations to manage a specific time entry.</returns>
    public TimeEntryRequestBuilder this[long timeEntryId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "timeentryid", timeEntryId } };
            return new TimeEntryRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of time entries.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries/#list-all-time-entries
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of time entries.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<TimeEntriesResponse> GetAsync(
        Action<TimeEntriesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<TimeEntriesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new time entry.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/timesheets-api/timesheets/time-entries
    /// </remarks>
    /// <param name="body">The time entry to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created time entry.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<TimeEntry> PostAsync(
        CreateTimeEntry body,
        Action<TimeEntriesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<TimeEntry>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of time entries.
    /// </summary>
    public class TimeEntriesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<TimeEntriesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create a time entry.
    /// </summary>
    public class TimeEntriesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of time entries.
    /// </summary>
    public class TimeEntriesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the ID of the user to filter by.
        /// </summary>
        [QueryParameter("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the client to filter by.
        /// </summary>
        [QueryParameter("client_id")]
        public long? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the project to filter by.
        /// </summary>
        [QueryParameter("project_id")]
        public long? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the ID of the task to filter by.
        /// </summary>
        [QueryParameter("task_id")]
        public long? TaskId { get; set; }

        /// <summary>
        /// Gets or sets the external reference ID to filter by.
        /// </summary>
        [QueryParameter("external_reference_id")]
        public string ExternalReferenceId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to filter by whether the time entry is invoiced.
        /// </summary>
        [QueryParameter("is_billed")]
        public bool? IsBilled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to filter by whether the time entry is running.
        /// </summary>
        [QueryParameter("is_running")]
        public bool? IsRunning { get; set; }

        /// <summary>
        /// Gets or sets the given date to return only time entries that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }

        /// <summary>
        /// Gets or sets the given date to return only time entries that have a SpentDate since or on that date.
        /// </summary>
        [QueryParameter("from")]
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the given date to return only time entries that have a SpentDate before or on that date.
        /// </summary>
        [QueryParameter("to")]
        public DateTime? To { get; set; }
    }
}