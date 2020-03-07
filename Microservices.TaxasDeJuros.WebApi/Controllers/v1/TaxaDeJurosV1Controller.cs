using Microservices.TaxasDeJuros.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/taxaJuros")]
    public class TaxaDeJurosV2Controller : ControllerBase
    {
        private readonly ITaxaDeJurosServices _taxaDeJurosServices;

        public TaxaDeJurosV2Controller(ITaxaDeJurosServices taxaDeJurosServices)
        {
            _taxaDeJurosServices = taxaDeJurosServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _taxaDeJurosServices.GetTaxaDeJurosPadraoAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro interno. Mensagem de erro: {ex.Message}");
            }
        }
    }
}