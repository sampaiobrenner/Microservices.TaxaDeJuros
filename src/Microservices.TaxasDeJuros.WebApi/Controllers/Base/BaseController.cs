using Microsoft.AspNetCore.Mvc;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.Base
{
    [ApiController, Route("api/v{version:apiVersion}")]
    public abstract class BaseController : ControllerBase
    {
    }
}