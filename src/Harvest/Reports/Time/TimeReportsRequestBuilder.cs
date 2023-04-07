namespace Harvest.Reports.Time;

using System;
using System.Collections.Generic;
using Common.Requests;

/// <summary>
/// Defines the builder for operations to manage time reports.
/// </summary>
public class TimeReportsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TimeReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public TimeReportsRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/reports/time", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage clients time reports.
    /// </summary>
    public ClientsTimeReportsRequestBuilder Clients => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage projects time reports.
    /// </summary>
    public ProjectsTimeReportsRequestBuilder Projects => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage tasks time reports.
    /// </summary>
    public TasksTimeReportsRequestBuilder Tasks => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage team time reports.
    /// </summary>
    public TeamTimeReportsRequestBuilder Team => new(this.PathParameters, this.RequestAdapter);
}