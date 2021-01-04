using Microservices.TaxasDeJuros.Domain;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Repositories
{
    public interface ITaxaDeJurosRepository
    {
        decimal GetValor<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros;

        Task<decimal> GetValorAsync<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros;
    }
}