using System.Threading.Tasks;
using server.Controllers.v2;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using server;

namespace integrationtests
{
    public class ControllerTest : IntergrationTest
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public ControllerTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        public async Task GetEndpoints_ReturnsSuccessResponse(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await TestClient.GetAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();

            Assert.Equal("text/html; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }
    }
}