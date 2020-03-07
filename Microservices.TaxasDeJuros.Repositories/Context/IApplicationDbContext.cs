using Microservices.TaxasDeJuros.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Context
{
    public interface IApplicationDbContext
    {
        DbSet<TaxaDeJuros> TaxasDeJuros { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}