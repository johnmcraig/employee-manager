using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using server.Data;
using server.Data.Entites;
using server.Dtos;
using Swashbuckle.AspNetCore.Swagger;

namespace server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EmployeeDbContext>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddCors(o => {
                o.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            services.AddMvc(opt => opt.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMvcCore().AddApiExplorer();

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV" );

            services.AddSwaggerGen(options => 
            {
                var provider = services.BuildServiceProvider()
                    .GetRequiredService<IApiVersionDescriptionProvider>();

                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(description.GroupName, new Info
                        { 
                            Title = $"Sample API {description.ApiVersion}", 
                            Version = description.ApiVersion.ToString() 
                        });
                    }
            });

            services.AddApiVersioning(
                options => {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.Conventions.Add( new VersionByNamespaceConvention());
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.ApiVersionReader = new HeaderApiVersionReader("api-version");
            });

            services.AddTransient<DataSeeder>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DataSeeder seedData, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            Mapper.Initialize(mapper =>
            {
                mapper.ValidateInlineMaps = false;
                mapper.CreateMissingTypeMaps = true;
                mapper.CreateMap<Employee, EmployeeDto>().ReverseMap();
                mapper.CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
                mapper.CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            });

            app.UseHttpsRedirection();

            app.UseForwardedHeaders(new ForwardedHeadersOptions {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                         description.GroupName.ToUpperInvariant());
                }
            });

            app.UseCors("CorsPolicy");

            seedData.SeedData().Wait();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes => {

                // comment out routes.MapRoute when using Angular build files in wwwroot
                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Fallback", action = "Index"} 
                );
                // uncomment below to use Vue build files in wwwroot
                // routes.MapRoute(
                //     name: "Root",
                //     template: "",
                //     defaults: new { controller = "Root", action = "Index"});

                // routes.MapRoute(
                //     name: "default",
                //     template: "{controller=Home}/{action=Index/{id?}",
                //     defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
