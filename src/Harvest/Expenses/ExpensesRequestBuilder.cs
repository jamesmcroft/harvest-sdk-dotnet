namespace Harvest.Expenses;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage expenses.
/// </summary>
public class ExpensesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpensesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ExpensesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base(
            "{+baseurl}/expenses{?user_id,client_id,project_id,is_billed,updated_since,from,to,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific expense.
    /// </summary>
    /// <param name="expenseId">The ID of the expense.</param>
    /// <returns>A builder for operations to manage a specific expense.</returns>
    public ExpenseRequestBuilder this[long expenseId]
    {
        get
        {
            var urlTemplateParams = new Dictionary<string, object>(this.PathParameters) { { "expenseid", expenseId } };
            return new ExpenseRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of expenses.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expenses/#list-all-expenses.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of expenses.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ExpensesResponse> GetAsync(
        Action<ExpensesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ExpensesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new expense.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expenses/#create-an-expense.
    /// </remarks>
    /// <param name="body">The expense to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created expense.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<Expense> PostAsync(
        CreateExpense body,
        Action<ExpensesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<Expense>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of expenses.
    /// </summary>
    public class ExpensesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<ExpensesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an expense.
    /// </summary>
    public class ExpensesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of expenses.
    /// </summary>
    public class ExpensesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets the user ID to return expenses that are assigned to that user.
        /// </summary>
        [QueryParameter("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Gets or sets the client ID to return expenses that are assigned to that client.
        /// </summary>
        [QueryParameter("client_id")]
        public long? ClientId { get; set; }

        /// <summary>
        /// Gets or sets the project ID to return expenses that are assigned to that project.
        /// </summary>
        [QueryParameter("project_id")]
        public long? ProjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to return expenses that have been invoiced.
        /// </summary>
        [QueryParameter("is_billed")]
        public bool? IsBilled { get; set; }

        /// <summary>
        /// Gets or sets the given date to return expenses that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }

        /// <summary>
        /// Gets or sets the date range from which to retrieve expenses.
        /// </summary>
        [QueryParameter("from")]
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets the date range to which to retrieve expenses.
        /// </summary>
        [QueryParameter("to")]
        public DateTime? To { get; set; }
    }
}