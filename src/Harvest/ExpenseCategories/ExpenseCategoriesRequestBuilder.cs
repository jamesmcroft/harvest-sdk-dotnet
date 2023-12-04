namespace Harvest.ExpenseCategories;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage expense categories.
/// </summary>
public class ExpenseCategoriesRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseCategoriesRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ExpenseCategoriesRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base(
            "{+baseurl}/expense_categories{?is_active,updated_since,page,per_page}",
            pathParameters,
            requestAdapter)
    {
    }

    /// <summary>
    /// Gets the builder for operations to manage a specific expense category.
    /// </summary>
    /// <param name="expenseCategoryId">The ID of the expense category.</param>
    /// <returns>A builder for operations to manage a specific expense category.</returns>
    public ExpenseCategoryRequestBuilder this[long expenseCategoryId]
    {
        get
        {
            var urlTemplateParams =
                new Dictionary<string, object>(this.PathParameters) { { "expensecategoryid", expenseCategoryId } };
            return new ExpenseCategoryRequestBuilder(urlTemplateParams, this.RequestAdapter);
        }
    }

    /// <summary>
    /// Retrieves a list of expense categories.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expense-categories/#list-all-expense-categories.
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A collection of expense categories.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ExpenseCategoriesResponse> GetAsync(
        Action<ExpenseCategoriesRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ExpenseCategoriesResponse>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Creates a new expense category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expense-categories/#create-an-expense-category.
    /// </remarks>
    /// <param name="body">The expense category to create.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The created expense category.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<ExpenseCategory> PostAsync(
        CreateExpenseCategory body,
        Action<ExpenseCategoriesRequestBuilderPostRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToPostRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<ExpenseCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to retrieve a list of expense categories.
    /// </summary>
    public class ExpenseCategoriesRequestBuilderGetRequestConfiguration
        : QueryableRequestConfiguration<ExpenseCategoriesRequestBuilderGetQueryParameters>
    {
    }

    /// <summary>
    /// Defines the configuration for the request to create an expense category.
    /// </summary>
    public class ExpenseCategoriesRequestBuilderPostRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the query parameters for the request to retrieve a list of expense categories.
    /// </summary>
    public class ExpenseCategoriesRequestBuilderGetQueryParameters : PaginatedQueryParameters
    {
        /// <summary>
        /// Gets or sets a value indicating whether to return expense categories that are active.
        /// </summary>
        [QueryParameter("is_active")]
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the given date to return expense categories that have been updated since that date.
        /// </summary>
        [QueryParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }
    }
}