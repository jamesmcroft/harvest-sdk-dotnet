namespace Harvest.Tests.Tests;

using System;
using Authentication;
using Common;
using Newtonsoft.Json;
using Shouldly;

[TestFixture]
public class AccessTokenTests
{
    public class WhenSerializingToJson : BaseTestFixture
    {
        [Test]
        public void ShouldDeserializeAllProperties()
        {
            // Arrange
            var accessToken = new AccessToken("token", DateTimeOffset.Now, "refreshToken");

            // Act
            string serialized = JsonConvert.SerializeObject(accessToken);
            AccessToken deserialized = JsonConvert.DeserializeObject<AccessToken>(serialized);

            // Assert
            deserialized.Token.ShouldBe(accessToken.Token);
            deserialized.ExpiresOn.ShouldBe(accessToken.ExpiresOn);
            deserialized.RefreshToken.ShouldBe(accessToken.RefreshToken);
        }
    }
}