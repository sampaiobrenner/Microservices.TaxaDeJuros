using Microservices.TaxasDeJuros.Services;
using Microservices.TaxasDeJuros.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.TaxasDeJuros.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxaDeJurosService, TaxaDeJurosService>();
            return services;
        }
    }
}