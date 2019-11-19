using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using server;

namespace integrationtests
{
    public class IntergrationTest
    {
        protected readonly HttpClient _client;
        public IntergrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }
    }
}