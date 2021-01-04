using System.Threading;
using System.Threading.Tasks;
using Microservices.TaxasDeJuros.Domain;
using Microservices.TaxasDeJuros.Repositories.Abstractions;
using Microservices.TaxasDeJuros.Services.Abstractions;

namespace Microservices.TaxasDeJuros.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        private readonly ITaxaDeJurosRepository _taxaDeJurosRepository;

        public TaxaDeJurosService(ITaxaDeJurosRepository taxaDeJurosRepository)
        {
            _taxaDeJurosRepository = taxaDeJurosRepository;
        }

        public decimal GetTaxaDeJurosPadrao()
        {
            return _taxaDeJurosRepository.GetValor<TaxaDeJurosPadrao>();
        }

        public Task<decimal> GetTaxaDeJurosReduzidaAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return _taxaDeJurosRepository.GetValorAsync<TaxaDeJurosReduzida>(cancellationToken);
        }
    }
}