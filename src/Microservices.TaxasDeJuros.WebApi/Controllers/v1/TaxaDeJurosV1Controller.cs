using Microservices.TaxasDeJuros.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microservices.TaxasDeJuros.Services.Abstractions;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class TaxaDeJurosV1Controller : BaseController
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public TaxaDeJurosV1Controller(ITaxaDeJurosService taxaDeJurosService)
        {
            _taxaDeJurosService = taxaDeJurosService;
        }

        [HttpGet("taxaJuros")]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _taxaDeJurosService.GetTaxaDeJurosReduzidaAsync(cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro interno. Mensagem de erro: {ex.Message}");
            }
        }
    }
}