using Microservices.TaxasDeJuros.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using Microservices.TaxasDeJuros.Services.Abstractions;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    public class TaxaDeJurosV2Controller : BaseController
    {
        private readonly ITaxaDeJurosService _taxaDeJurosService;

        public TaxaDeJurosV2Controller(ITaxaDeJurosService taxaDeJurosService) => _taxaDeJurosService = taxaDeJurosService;

        [HttpGet("taxaJurosPadrao")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_taxaDeJurosService.GetTaxaDeJurosPadrao());
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocorreu um erro interno. Mensagem de erro: {ex.Message}");
            }
        }
    }
}