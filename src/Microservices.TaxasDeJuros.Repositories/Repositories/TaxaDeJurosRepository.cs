using Microservices.TaxasDeJuros.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microservices.TaxasDeJuros.Domain.Abstractions;
using Microservices.TaxasDeJuros.Repositories.Abstractions;

namespace Microservices.TaxasDeJuros.Repositories.Repositories
{
    public class TaxaDeJurosRepository : ITaxaDeJurosRepository
    {
        private readonly TaxaDeJurosDbContext _context;

        public TaxaDeJurosRepository(TaxaDeJurosDbContext context)
        {
            _context = context;
        }

        public decimal GetValor<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros
        {
            return _context.TaxasDeJuros.OfType<TTaxaDeJuros>().Select(x => x.Valor).FirstOrDefault();
        }

        public Task<decimal> GetValorAsync<TTaxaDeJuros>(CancellationToken cancellationToken) where TTaxaDeJuros : TaxaDeJuros
        {
            return _context.TaxasDeJuros.OfType<TTaxaDeJuros>().Select(x => x.Valor).FirstOrDefaultAsync(cancellationToken);
        }
    }
}