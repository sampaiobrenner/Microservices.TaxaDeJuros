using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Services.Services
{
    public interface ITaxaDeJurosServices
    {
        decimal GetTaxaDeJurosPadrao();

        Task<decimal> GetTaxaDeJurosReduzidaAsync();
    }
}