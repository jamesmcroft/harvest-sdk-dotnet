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
public class InvoicesRequestBuilderTests
{
    public class WhenListingInvoices : BaseTestFixture
    {
        [Test]
        public async Task ShouldSetQueryParameters()
        {
            // Arrange
            (HarvestServiceClient harvestServiceClient, Mock<HttpMessageHandler> httpMessageHandler) =
                this.GetHarvestServiceClient();

            long clientId = 2341;
            long projectId = 3412;
            var updatedSince = new DateTime(2023, 4, 9);
            var from = new DateTime(2023, 4, 1);
            var to = new DateTime(2023, 4, 10);
            int page = 2;
            int perPage = 100;

            string expectedRequestUrl =
                $"https://api.harvestapp.com/v2/invoices?client_id={clientId}&project_id={projectId}&updated_since={HttpUtility.UrlEncode(updatedSince.ToString("O"))}&from={HttpUtility.UrlEncode(from.ToString("O"))}&to={HttpUtility.UrlEncode(to.ToString("O"))}&page={page}&per_page={perPage}"
                    .ToLowerInvariant();

            // Act
            await harvestServiceClient.Invoices.GetAsync(c =>
            {
                c.QueryParameters.ClientId = clientId;
                c.QueryParameters.ProjectId = projectId;
                c.QueryParameters.UpdatedSince = updatedSince;
                c.QueryParameters.From = from;
                c.QueryParameters.To = to;
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