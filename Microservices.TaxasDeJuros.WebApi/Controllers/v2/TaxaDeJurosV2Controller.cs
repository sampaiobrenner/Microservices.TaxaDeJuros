using Microsoft.AspNetCore.Mvc;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v2
{
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/taxaJuros")]
    public class TaxaDeJurosV2Controller : ControllerBase
    {
    }
}