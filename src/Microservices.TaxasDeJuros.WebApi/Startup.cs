using Microservices.TaxasDeJuros.WebApi.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservices.TaxasDeJuros.WebApi
{
    public class Startup
    {
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.MigrateDatabase();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services
                .AddApiVersioning()
                .AddServices()
                .AddRepositories();
            
        }
    }
}