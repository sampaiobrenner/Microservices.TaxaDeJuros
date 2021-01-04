using Microservices.TaxasDeJuros.Repositories.Context;
using Microservices.TaxasDeJuros.Repositories.Repositories;
using Microservices.TaxasDeJuros.Repositories.Seeds;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.TaxasDeJuros.Repositories
{
    public static class IocRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxaDeJurosRepository, TaxaDeJurosRepository>();
            services.AddScoped<ISeed, Seed>();
        }
    }
}