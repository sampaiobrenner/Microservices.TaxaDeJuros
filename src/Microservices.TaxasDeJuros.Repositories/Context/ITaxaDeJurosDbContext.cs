using Microservices.TaxasDeJuros.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Context
{
    public interface ITaxaDeJurosDbContext
    {
        DbSet<TaxaDeJuros> TaxasDeJuros { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}