using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LiteAnalytics.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddResponseCompression();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseResponseCompression();
            app.UseRouter(r =>
            {
                r.MapGet("status", async (request, response, routeData) => { await response.WriteAsync("Hello, World", Encoding.UTF8); });
                
                RegisterPropertyAdministrationEndpoints("api", r);
            });
        }

        private void RegisterPropertyAdministrationEndpoints(string basePath, IRouteBuilder r)
        {
            r.MapPut($"{basePath}/property", 
                async (request, response, routeData) => { await response.WriteAsync("{ \"id\": \"1234\" }", Encoding.UTF8); });
        }
    }
}
