namespace Harvest.Expenses;

using System.Collections.Generic;
using Common.Requests;

public class ExpensesRequestBuilder : RequestBuilder
{
    public ExpensesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/", pathParameters, requestAdapter)
    {
    }
}