using Microservices.TaxasDeJuros.Domain;
using Microservices.TaxasDeJuros.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Repositories
{
    public class TaxaDeJurosRepository : ITaxaDeJurosRepository
    {
        private readonly TaxaDeJurosDbContext _context;

        public TaxaDeJurosRepository(TaxaDeJurosDbContext context) => _context = context;

        public decimal GetValor<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros =>
            _context.TaxasDeJuros.OfType<TTaxaDeJuros>().Select(x => x.Valor).FirstOrDefault();

        public Task<decimal> GetValorAsync<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros =>
            _context.TaxasDeJuros.OfType<TTaxaDeJuros>().Select(x => x.Valor).FirstOrDefaultAsync();
    }
}