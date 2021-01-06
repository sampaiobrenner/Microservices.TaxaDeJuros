using System.Threading;
using System.Threading.Tasks;
using Microservices.TaxasDeJuros.Domain;
using Microservices.TaxasDeJuros.Repositories.Abstractions;
using Microservices.TaxasDeJuros.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace Microservices.TaxasDeJuros.Services
{
    public class TaxaDeJurosService : ITaxaDeJurosService
    {
        private readonly ITaxaDeJurosRepository _taxaDeJurosRepository;
        private readonly ILogger<ITaxaDeJurosService> _logger;

        public TaxaDeJurosService(ITaxaDeJurosRepository taxaDeJurosRepository, ILogger<ITaxaDeJurosService> logger)
        {
            _taxaDeJurosRepository = taxaDeJurosRepository;
            _logger = logger;
        }

        public decimal GetTaxaDeJurosPadrao()
        {
            var taxaDeJurosPadrao = _taxaDeJurosRepository.GetValor<TaxaDeJurosPadrao>();
            _logger.LogInformation("Taxa de juros padrão: {taxaDeJurosPadrao}", taxaDeJurosPadrao);
            return taxaDeJurosPadrao;
        }

        public async Task<decimal> GetTaxaDeJurosReduzidaAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var taxaDeJurosReduzida = await _taxaDeJurosRepository.GetValorAsync<TaxaDeJurosReduzida>(cancellationToken);
            _logger.LogInformation("Taxa de juros reduzida: {taxaDeJurosReduzida}", taxaDeJurosReduzida);
            return taxaDeJurosReduzida;
        }
    }
}