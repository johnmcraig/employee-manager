using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using server;
using server.Data;

namespace integrationtests
{
    public class IntergrationTest
    {
        protected readonly HttpClient _client;
        public IntergrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => {
                    builder.ConfigureServices(services => {
                        services.RemoveAll(typeof(EmployeeDbContext));
                        services.AddDbContext<DbContext>(opt => {
                            opt.UseInMemoryDatabase("TestDatabase");
                        });
                    });
                });

            _client = appFactory.CreateClient();
        }
    }
}