using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        public ActionResult UserAddV1(string firstName, string lastName)
        {

            return StatusCode(201);
        }
        [HttpGet]
        [Route("all")]
        public string GetAllUsersV1()
        {
            return "kullanıcı listesi[]";
        }
    }
}
