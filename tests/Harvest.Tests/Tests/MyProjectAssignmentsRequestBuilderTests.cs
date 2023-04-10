namespace Harvest.Tests.Tests;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Moq;
using Moq.Protected;

[TestFixture]
public class MyProjectAssignmentsRequestBuilderTests
{
    public class WhenListingProjectAssignments : BaseTestFixture
    {
        [Test]
        public async Task ShouldSetQueryParameters()
        {
            // Arrange
            (HarvestServiceClient harvestServiceClient, Mock<HttpMessageHandler> httpMessageHandler) =
                this.GetHarvestServiceClient();

            int page = 2;
            int perPage = 100;

            string expectedRequestUrl =
                $"https://api.harvestapp.com/v2/users/me/project_assignments?page={page}&per_page={perPage}"
                    .ToLowerInvariant();

            // Act
            await harvestServiceClient.Users.Me.ProjectAssignments.GetAsync(c =>
            {
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