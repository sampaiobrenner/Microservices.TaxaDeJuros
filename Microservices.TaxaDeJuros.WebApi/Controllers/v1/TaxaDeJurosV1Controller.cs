using Microsoft.AspNetCore.Mvc;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/taxaJuros")]
    public class TaxaDeJurosV2Controller : ControllerBase
    {
    }
}