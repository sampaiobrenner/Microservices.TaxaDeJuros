using Microservices.TaxasDeJuros.Repositories.Abstractions;
using Microservices.TaxasDeJuros.Repositories.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.TaxasDeJuros.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<TaxaDeJurosDbContext>();
            if (context is null) return app;
            context.Database.EnsureCreated();

            var seed = serviceScope.ServiceProvider.GetRequiredService<ISeed>();
            seed.Execute();
            return app;
        }
    }
}