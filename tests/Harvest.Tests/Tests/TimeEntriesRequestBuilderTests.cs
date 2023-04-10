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
public class TimeEntriesRequestBuilderTests
{
    public class WhenListingTimeEntries : BaseTestFixture
    {
        [Test]
        public async Task ShouldSetQueryParameters()
        {
            // Arrange
            (HarvestServiceClient harvestServiceClient, Mock<HttpMessageHandler> httpMessageHandler) =
                this.GetHarvestServiceClient();

            long userId = 1234;
            long clientId = 2341;
            long projectId = 3412;
            long taskId = 4123;
            string externalReferenceId = "abc";
            bool isBilled = true;
            bool isRunning = true;
            var updatedSince = new DateTime(2023, 4, 9);
            var from = new DateTime(2023, 4, 1);
            var to = new DateTime(2023, 4, 10);
            int page = 2;
            int perPage = 100;

            string expectedRequestUrl =
                $"https://api.harvestapp.com/v2/time_entries?user_id={userId}&client_id={clientId}&project_id={projectId}&task_id={taskId}&external_reference_id={externalReferenceId}&is_billed={isBilled}&is_running={isRunning}&updated_since={HttpUtility.UrlEncode(updatedSince.ToString("O"))}&from={HttpUtility.UrlEncode(from.ToString("O"))}&to={HttpUtility.UrlEncode(to.ToString("O"))}&page={page}&per_page={perPage}"
                    .ToLowerInvariant();

            // Act
            await harvestServiceClient.TimeEntries.GetAsync(c =>
            {
                c.QueryParameters.UserId = userId;
                c.QueryParameters.ClientId = clientId;
                c.QueryParameters.ProjectId = projectId;
                c.QueryParameters.TaskId = taskId;
                c.QueryParameters.ExternalReferenceId = externalReferenceId;
                c.QueryParameters.IsBilled = isBilled;
                c.QueryParameters.IsRunning = isRunning;
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