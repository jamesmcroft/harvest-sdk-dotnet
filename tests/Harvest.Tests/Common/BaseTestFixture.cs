using System.Diagnostics.CodeAnalysis;

[assembly: ExcludeFromCodeCoverage]
[assembly: LevelOfParallelism(5)]
[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace Harvest.Tests.Common;

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Authentication;
using Harvest.Common.Requests;
using Moq;
using Moq.Protected;

public class BaseTestFixture
{
    public (HarvestServiceClient Client, Mock<HttpMessageHandler> HttpMessageHandler) GetHarvestServiceClient(
        Action<Mock<HttpMessageHandler>> configure = default)
    {
        (HttpClient httpClient, Mock<HttpMessageHandler> httpMessageHandler) = GetMockHttpClient(configure);
        var harvestServiceClient =
            new HarvestServiceClient(new HarvestRequestAdapter(new PATCredential("access_token"), httpClient),
                "HarvestTests");
        return (harvestServiceClient, httpMessageHandler);
    }

    private static (HttpClient HttpClient, Mock<HttpMessageHandler> HttpMessageHandler) GetMockHttpClient(
        Action<Mock<HttpMessageHandler>> configure = default)
    {
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

        if (configure == null)
        {
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK });
        }
        else
        {
            configure(mockHttpMessageHandler);
        }

        return (new HttpClient(mockHttpMessageHandler.Object), mockHttpMessageHandler);
    }
}