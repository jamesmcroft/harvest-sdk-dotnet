namespace Harvest.Reports.Expenses;

using System.Collections.Generic;

using System;
using Common.Requests;

/// <summary>
/// Defines the builder for operations to manage expense reports.
/// </summary>
public class ExpenseReportsRequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ExpenseReportsRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
    {
        _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
        _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));

        this.UrlTemplate = "{+baseurl}/reports/expenses";
        this.PathParameters = new Dictionary<string, object>(pathParameters);
        this.RequestAdapter = requestAdapter;
    }

    /// <summary>
    /// Gets the builder for operations to manage clients expense reports.
    /// </summary>
    public ClientsExpenseReportsRequestBuilder Clients => new(this.PathParameters, this.RequestAdapter);

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