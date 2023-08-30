using Microsoft.AspNetCore.Mvc;

namespace Appizsoft.Api.Controllers
{
    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
