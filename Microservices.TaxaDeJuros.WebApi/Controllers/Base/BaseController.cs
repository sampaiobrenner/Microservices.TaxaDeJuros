using Microsoft.AspNetCore.Mvc;

namespace Microservices.TaxasDeJuros.WebApi.Controllers.Base
{
    [ApiController, Route("api/v{version:apiVersion}/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}