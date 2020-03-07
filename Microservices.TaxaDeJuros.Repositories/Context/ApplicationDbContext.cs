using Microservices.TaxasDeJuros.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservices.TaxasDeJuros.Repositories.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaxaDeJuros> TaxasDeJuros { get; set; }
    }
}