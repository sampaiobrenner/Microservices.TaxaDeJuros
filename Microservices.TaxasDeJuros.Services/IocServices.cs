using Microservices.TaxasDeJuros.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.TaxasDeJuros.Services
{
    public static class IocServices
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxaDeJurosServices, TaxaDeJurosServices>();
        }
    }
}