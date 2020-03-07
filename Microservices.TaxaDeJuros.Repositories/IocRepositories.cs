using Microservices.TaxasDeJuros.Repositories.Context;
using Microservices.TaxasDeJuros.Repositories.Seeds;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.TaxasDeJuros.Repositories
{
    public static class IocRepositories
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ISeed, Seed>();
        }
    }
}