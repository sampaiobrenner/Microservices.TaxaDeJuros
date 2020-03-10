using Microservices.TaxasDeJuros.Services.Services;
using Microservices.TaxasDeJuros.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    public class TaxaDeJurosV2Controller : BaseController
    {
        private readonly ITaxaDeJurosServices _taxaDeJurosServices;

        public TaxaDeJurosV2Controller(ITaxaDeJurosServices taxaDeJurosServices) => _taxaDeJurosServices = taxaDeJurosServices;

        [HttpGet("taxaJurosPadrao")]
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