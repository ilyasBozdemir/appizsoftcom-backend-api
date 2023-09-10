

using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
       
        
        [HttpGet("get-user")]
        public string GetUserV1()
        {
            return "sdgdsg2";
        }
    }
}
