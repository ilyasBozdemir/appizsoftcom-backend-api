using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Persistence.Repositories.Entity_Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {

        [HttpGet("get-user")]
        public string GetUserV1()
        {

            return "v1";
        }
    }
}
