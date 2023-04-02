namespace Harvest.Reports;

using System;
using System.Collections.Generic;
using Common.Requests;
using Expenses;
using ProjectBudget;
using Time;
using Uninvoiced;

/// <summary>
/// Defines the builder for operations to manage reports.
/// </summary>
public class ReportsRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ReportsRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/reports";
        this.PathParameters = new Dictionary<string, object>(pathParameters);
        this.RequestAdapter = requestAdapter;
    }

    /// <summary>
    /// Gets the builder for operations to manage expense reports.
    /// </summary>
    public ExpenseReportsRequestBuilder Expenses => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage uninvoiced reports.
    /// </summary>
    public UninvoicedReportsRequestBuilder Uninvoiced => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage time reports.
    /// </summary>
    public TimeReportsRequestBuilder Time => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage project budget reports.
    /// </summary>
    public ProjectBudgetReportsRequestBuilder ProjectBudget => new(this.PathParameters, this.RequestAdapter);

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
}