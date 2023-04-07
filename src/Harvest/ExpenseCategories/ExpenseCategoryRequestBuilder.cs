namespace Harvest.ExpenseCategories;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.Requests;
using Models;

/// <summary>
/// Defines the builder for operations to manage a specific expense category.
/// </summary>
public class ExpenseCategoryRequestBuilder : RequestBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExpenseCategoryRequestBuilder"/> class with the specified path parameters and request adapter.
    /// </summary>
    /// <param name="pathParameters">The default path parameters to use to build the request URL.</param>
    /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="pathParameters"/> or <paramref name="requestAdapter"/> is <see langword="null"/>.</exception>
    public ExpenseCategoryRequestBuilder(
        Dictionary<string, object> pathParameters,
        HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/expense_categories/{+expensecategoryid}", pathParameters, requestAdapter)
    {
    }

    /// <summary>
    /// Retrieves an expense category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expense-categories/#retrieve-an-expense-category
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The expense category details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task<ExpenseCategory> GetAsync(
        Action<ExpenseCategoryRequestBuilderGetRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToGetRequestInformation(requestConfiguration);
        return await this.RequestAdapter.SendAsync<ExpenseCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Updates an expense category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expense-categories/#update-an-expense-category
    /// </remarks>
    /// <param name="body">The expense category details to update. Any parameters not provided will be left unchanged.</param>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>The updated expense category details.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    /// <exception cref="ArgumentNullException">Thrown when the <paramref name="body"/> is <see langword="null"/>.</exception>
    public async Task<ExpenseCategory> PatchAsync(
        UpdateExpenseCategory body,
        Action<ExpenseCategoryRequestBuilderPatchRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        _ = body ?? throw new ArgumentNullException(nameof(body));
        RequestInformation requestInfo = this.ToPatchRequestInformation(body, requestConfiguration);
        return await this.RequestAdapter.SendAsync<ExpenseCategory>(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Deletes an expense category.
    /// </summary>
    /// <remarks>
    /// For more information: https://help.getharvest.com/api-v2/expenses-api/expenses/expense-categories/#delete-an-expense-category
    /// </remarks>
    /// <param name="requestConfiguration">The configuration for the request such as headers.</param>
    /// <param name="cancellationToken">The optional cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    /// <exception cref="HttpRequestException">Thrown when the request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    public async Task DeleteAsync(
        Action<ExpenseCategoryRequestBuilderDeleteRequestConfiguration> requestConfiguration = default,
        CancellationToken cancellationToken = default)
    {
        RequestInformation requestInfo = this.ToDeleteRequestInformation(requestConfiguration);
        await this.RequestAdapter.SendAsync(requestInfo, cancellationToken);
    }

    /// <summary>
    /// Defines the configuration for the request to get an expense category.
    /// </summary>
    public class ExpenseCategoryRequestBuilderGetRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Defines the configuration for the request to update an expense category.
    /// </summary>
    public class ExpenseCategoryRequestBuilderPatchRequestConfiguration : RequestConfiguration
    {
    }

    /// <summary>
    /// Define the configuration for the request to delete an expense category.
    /// </summary>
    public class ExpenseCategoryRequestBuilderDeleteRequestConfiguration : RequestConfiguration
    {
    }
}