using Microservices.TaxasDeJuros.Entities.Entities;
using Microservices.TaxasDeJuros.Repositories.Repositories;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Services.Services
{
    public class TaxaDeJurosServices : ITaxaDeJurosServices
    {
        private readonly ITaxaDeJurosRepository _taxaDeJurosRepository;

        public TaxaDeJurosServices(ITaxaDeJurosRepository taxaDeJurosRepository) => _taxaDeJurosRepository = taxaDeJurosRepository;

        public decimal GetTaxaDeJurosPadrao() => _taxaDeJurosRepository.GetValor<TaxaDeJurosPadrao>();

        public Task<decimal> GetTaxaDeJurosReduzidaAsync() => _taxaDeJurosRepository.GetValorAsync<TaxaDeJurosReduzida>();
    }
}