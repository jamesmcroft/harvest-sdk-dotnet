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
public class ProjectsRequestBuilderTests
{
    public class WhenListingProjects : BaseTestFixture
    {
        [Test]
        public async Task ShouldSetQueryParameters()
        {
            // Arrange
            (HarvestServiceClient harvestServiceClient, Mock<HttpMessageHandler> httpMessageHandler) =
                this.GetHarvestServiceClient();

            bool isActive = true;
            long clientId = 1234;
            var updatedSince = new DateTime(2023, 4, 9);
            int page = 2;
            int perPage = 100;

            string expectedRequestUrl =
                $"https://api.harvestapp.com/v2/projects?is_active={isActive}&client_id={clientId}&updated_since={HttpUtility.UrlEncode(updatedSince.ToString("O"))}&page={page}&per_page={perPage}"
                    .ToLowerInvariant();

            // Act
            await harvestServiceClient.Projects.GetAsync(c =>
            {
                c.QueryParameters.IsActive = isActive;
                c.QueryParameters.ClientId = clientId;
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