using Microservices.TaxasDeJuros.Entities.Entities;
using Microservices.TaxasDeJuros.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Repositories
{
    public class TaxaDeJurosRepository : ITaxaDeJurosRepository
    {
        private readonly IApplicationDbContext _context;

        public TaxaDeJurosRepository(IApplicationDbContext context) => _context = context;

        public Task<decimal> GetTaxaDeJurosPadrao() =>
            _context.TaxasDeJuros
                .Where(x => x is TaxaDeJurosPadrao)
                .Select(x => x.Valor)
                .FirstOrDefaultAsync();
    }
}