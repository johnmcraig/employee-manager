using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using server;
using server.Data;
using System.Net.Http.Headers;
using System;

namespace integrationtests
{
    public class IntergrationTest
    {
        protected readonly HttpClient TestClient;
        protected IntergrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder => 
                {
                    builder.ConfigureServices(services => 
                    {
                        services.RemoveAll(typeof(EmployeeDbContext));
                        services.AddDbContext<EmployeeDbContext>(opt => 
                        {
                            opt.UseInMemoryDatabase("TestDatabase");
                        });
                    });
                });

            TestClient = appFactory.CreateClient();
        }

        protected async Task AuthinticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        protected async Task<string> GetJwtAsync()
        {
            throw new NotImplementedException();
        }
    }
}