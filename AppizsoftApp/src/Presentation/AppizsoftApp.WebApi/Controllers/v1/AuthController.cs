using AppizsoftApp.Application.Constants;
using AppizsoftApp.Application.CustomAttributes;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Features.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v1
{
    /// <summary>
    /// Kimlik doğrulama ve oturum yönetimi işlemlerini yöneten API kontrolcüsü.
    /// </summary>
    [Route("api/v1/auth")]
    [ApiVersion("1")]
    [ApiController]
    [RequireAnyRole(Roles.SuperAdmin | Roles.Admin | Roles.Editor)]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }

}
