namespace Harvest.Tests.Tests;

using System;
using System.Collections.Generic;
using Authentication;
using Common;
using Shouldly;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public class HarvestServiceClientTests
{
    public class WhenAuthenticating : BaseTestFixture
    {
        [Test]
        public void ShouldBuildAuthorizationUrlForOAuthCredential()
        {
            // Arrange
            var authCredential = new OAuthCredential("clientId", "clientSecret", new Uri("https://localhost:8080/"));
            var harvestServiceClient = new HarvestServiceClient(authCredential, "applicationId");

            // Act
            Uri authorizationUrl = harvestServiceClient.BuildAuthorizationUrl();

            // Assert
            authorizationUrl.ShouldNotBeNull();
            authorizationUrl.ToString().ShouldStartWith("https://id.getharvest.com/oauth2/authorize");

            Dictionary<string, string> queryParts = authorizationUrl.DeconstructQuery();
            queryParts["client_id"].ShouldBe("clientId");
            queryParts["redirect_uri"].ShouldBe("https%3A%2F%2Flocalhost%3A8080%2F");
            queryParts["scope"].ShouldBe("harvest%3Aall");
            queryParts["response_type"].ShouldBe("code");
            queryParts["state"].ShouldNotBeNullOrEmpty();
        }

        [Test]
        public void ShouldThrowInvalidOperationExceptionWhenBuildAuthorizationUrlWithoutOAuthCredential()
        {
            // Arrange
            var authCredential = new PATCredential("pat");
            var harvestServiceClient = new HarvestServiceClient(authCredential, "applicationId");

            // Act & Assert
            Should.Throw<InvalidOperationException>(() => harvestServiceClient.BuildAuthorizationUrl());
        }
    }
}