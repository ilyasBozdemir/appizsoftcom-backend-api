using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Application.Exceptions.UserExceptions;
using AppizsoftApp.Application.Features.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        public UsersController(IMediator mediator)
        {
            
        }
    }
}
