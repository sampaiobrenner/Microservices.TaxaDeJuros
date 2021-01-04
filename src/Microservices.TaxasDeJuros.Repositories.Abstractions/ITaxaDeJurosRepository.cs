using System.Threading;
using System.Threading.Tasks;
using Microservices.TaxasDeJuros.Domain.Abstractions;

namespace Microservices.TaxasDeJuros.Repositories.Abstractions
{
    public interface ITaxaDeJurosRepository
    {
        decimal GetValor<TTaxaDeJuros>() where TTaxaDeJuros : TaxaDeJuros;

        Task<decimal> GetValorAsync<TTaxaDeJuros>(CancellationToken cancellationToken) where TTaxaDeJuros : TaxaDeJuros;
    }
}