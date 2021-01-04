using System.Threading;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Services.Abstractions
{
    public interface ITaxaDeJurosService
    {
        decimal GetTaxaDeJurosPadrao();

        Task<decimal> GetTaxaDeJurosReduzidaAsync(CancellationToken cancellationToken);
    }
}