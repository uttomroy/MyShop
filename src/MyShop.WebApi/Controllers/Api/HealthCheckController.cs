using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace MyShop.WebApi.Controllers.Api
{
    public class HealthCheckController : ControllerBase
    {
        [Route("/api/health")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
        [SwaggerOperation(OperationId = "Index")]
        public IActionResult Index() => Ok(); 
    }
}
