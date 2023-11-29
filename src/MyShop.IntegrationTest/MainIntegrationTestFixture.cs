using Microsoft.AspNetCore.Mvc.Testing;
using Shouldly;

namespace MyShop.IntegrationTest
{
    [TestFixture]
    public class MainIntegrationTestFixture
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MainIntegrationTestFixture()
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [Test]
        public async Task WhenSendPostToHealthCheckEndpoint_ShouldReturnOkResponse()
        {
            var client = _factory.CreateClient();
            var result = await client.GetAsync("api/health");
            result.IsSuccessStatusCode.ShouldBeTrue();
        }
    }
}
