using Microservices.TaxasDeJuros.Repositories.Abstractions;
using Microservices.TaxasDeJuros.Repositories.Context;
using Microservices.TaxasDeJuros.Repositories.Repositories;
using Microservices.TaxasDeJuros.Repositories.Seeds;
using Microservices.TaxasDeJuros.Services;
using Microservices.TaxasDeJuros.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.TaxasDeJuros.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) 
            => services
                .AddScoped<ITaxaDeJurosService, TaxaDeJurosService>();

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddDbContext<TaxaDeJurosDbContext>(opt => opt.UseInMemoryDatabase("microservices-taxa-de-juros"));

            return services
                .AddScoped<ITaxaDeJurosRepository, TaxaDeJurosRepository>()
                .AddScoped<ISeed, Seed>();
        }
    }
}