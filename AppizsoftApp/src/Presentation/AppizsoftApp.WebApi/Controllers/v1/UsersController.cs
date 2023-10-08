using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
