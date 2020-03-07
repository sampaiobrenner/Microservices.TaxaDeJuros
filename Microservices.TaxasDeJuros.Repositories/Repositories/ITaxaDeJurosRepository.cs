using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.Repositories.Repositories
{
    public interface ITaxaDeJurosRepository
    {
        Task<decimal> GetTaxaDeJurosPadrao();
    }
}