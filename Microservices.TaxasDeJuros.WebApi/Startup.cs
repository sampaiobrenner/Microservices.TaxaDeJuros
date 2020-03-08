using Microservices.TaxasDeJuros.Repositories;
using Microservices.TaxasDeJuros.Repositories.Context;
using Microservices.TaxasDeJuros.Repositories.Seeds;
using Microservices.TaxasDeJuros.Services;
using Microservices.TaxasDeJuros.WebApi.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Microservices.TaxasDeJuros.WebApi
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            // Habilita o middleware para servir o Swagger gerado como um endpoint JSON
            app.UseSwagger();

            // Habilita o middleware para servir o swagger-ui, especificando o endpoint Swagger JSON
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });

            MigrateDatabase(app);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApiVersioning();

            // Registra o gerador Swagger definindo um ou mais documentos Swagger
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDbContext>(opt => opt.UseInMemoryDatabase("microservices-taxa-de-juros"));

            IocServices.Register(services);
            IocRepositories.Register(services);
        }

        private void MigrateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();

            var seed = serviceScope.ServiceProvider.GetService<ISeed>();
            seed.Execute();
        }
    }
}