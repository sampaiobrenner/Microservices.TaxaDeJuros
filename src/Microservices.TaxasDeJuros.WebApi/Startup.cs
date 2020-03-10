using Microservices.TaxasDeJuros.Repositories;
using Microservices.TaxasDeJuros.Repositories.Context;
using Microservices.TaxasDeJuros.Repositories.Seeds;
using Microservices.TaxasDeJuros.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Microservices.TaxasDeJuros.WebApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            MigrateDatabase(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            services.AddDbContext<TaxaDeJurosDbContext>(opt => opt.UseInMemoryDatabase("microservices-taxa-de-juros"));

            IocServices.Register(services);
            IocRepositories.Register(services);
        }

        private void MigrateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TaxaDeJurosDbContext>();
            context.Database.EnsureCreated();

            var seed = serviceScope.ServiceProvider.GetService<ISeed>();
            seed.Execute();
        }
    }
}