namespace Harvest.Tests.Common;

using System;
using System.Collections.Generic;
using System.Linq;

internal static class UriExtensions
{
    internal static Dictionary<string, string> DeconstructQuery(this Uri authorizationUrl)
    {
        string query = authorizationUrl.Query.TrimStart('?');
        string[] queryParts = query.Split('&');
        return queryParts.Select(queryPart => queryPart.Split('='))
            .ToDictionary(keyValue => keyValue[0], keyValue => keyValue[1]);
    }
}