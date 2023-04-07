namespace Harvest.Invoices;

using System.Collections.Generic;
using Common.Requests;

public class InvoicesRequestBuilder : RequestBuilder
{
    public InvoicesRequestBuilder(Dictionary<string, object> pathParameters, HarvestRequestAdapter requestAdapter)
        : base("{+baseurl}/", pathParameters, requestAdapter)
    {
    }
}