using Microservices.TaxasDeJuros.Entities.Entities;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Repositories
{
    public interface ITaxaDeJurosRepository
    {
        Task<decimal> GetValor<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros;
    }
}