namespace Harvest.Tests.Tests;

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Common;
using Moq;
using Moq.Protected;

[TestFixture]
public class TasksRequestBuilderTests
{
    public class WhenListingTasks : BaseTestFixture
    {
        [Test]
        public async Task ShouldSetQueryParameters()
        {
            // Arrange
            (HarvestServiceClient harvestServiceClient, Mock<HttpMessageHandler> httpMessageHandler) =
                this.GetHarvestServiceClient();

            bool isActive = true;
            var updatedSince = new DateTime(2023, 4, 9);
            int page = 2;
            int perPage = 100;

            string expectedRequestUrl =
                $"https://api.harvestapp.com/v2/tasks?is_active={isActive}&updated_since={HttpUtility.UrlEncode(updatedSince.ToString("O"))}&page={page}&per_page={perPage}"
                    .ToLowerInvariant();

            // Act
            await harvestServiceClient.Tasks.GetAsync(c =>
            {
                c.QueryParameters.IsActive = isActive;
                c.QueryParameters.UpdatedSince = updatedSince;
                c.QueryParameters.Page = page;
                c.QueryParameters.PerPage = perPage;
            });

            // Assert
            httpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.RequestUri.ToString().ToLowerInvariant() == expectedRequestUrl),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}