using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v2
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v2/[controller]")]
    public class UsersController : ControllerBase
    {

        [HttpGet("get-user")]
        public string GetUserV2()
        {
            return "v2";
        }
    }
}
