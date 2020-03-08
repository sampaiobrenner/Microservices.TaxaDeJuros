using Microservices.TaxasDeJuros.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/taxaJuros")]
    public class TaxaDeJurosV2Controller : ControllerBase
    {
        private readonly ITaxaDeJurosServices _taxaDeJurosServices;

        public TaxaDeJurosV2Controller(ITaxaDeJurosServices taxaDeJurosServices) => _taxaDeJurosServices = taxaDeJurosServices;

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_taxaDeJurosServices.GetTaxaDeJurosPadrao());
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro interno. Mensagem de erro: {ex.Message}");
            }
        }
    }
}