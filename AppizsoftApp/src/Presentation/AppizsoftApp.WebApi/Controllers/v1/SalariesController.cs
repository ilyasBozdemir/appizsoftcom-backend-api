using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
