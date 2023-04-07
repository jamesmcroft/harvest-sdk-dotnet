namespace Harvest.Reports.Expenses;

using System;
using System.Collections.Generic;
using Common.Requests;

/// <summary>
/// Defines the builder for operations to manage expense reports.
/// </summary>
public class ExpenseReportsRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseReportsRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ExpenseReportsRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/reports/expenses", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage clients expense reports.
    /// </summary>
    public ClientsExpenseReportsRequestBuilder Clients => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage projects expense reports.
    /// </summary>
    public ProjectsExpenseReportsRequestBuilder Projects => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage categories expense reports.
    /// </summary>
    public CategoriesExpenseReportsRequestBuilder Categories => new(this.PathParameters, this.RequestAdapter);

    /// <summary>
    /// Gets the builder for operations to manage team expense reports.
    /// </summary>
    public TeamExpenseReportsRequestBuilder Team => new(this.PathParameters, this.RequestAdapter);
}