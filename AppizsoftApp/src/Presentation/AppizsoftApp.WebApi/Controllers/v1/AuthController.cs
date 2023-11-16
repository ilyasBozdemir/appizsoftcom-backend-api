using AppizsoftApp.Application.Constants;
using AppizsoftApp.Application.CustomAttributes;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Features.Commands.AppUser.GoogleLogin;
using AppizsoftApp.Application.Features.Commands.AppUser.LoginUser;
using AppizsoftApp.Application.Features.Commands.AppUser.RefreshTokenLogin;
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

        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Auths, ActionType = ActionType.Writing, Definition = "login user action")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);

            return new JsonResult(response.Success
                ? new { token = response.Token }
                : new { errors = response.Errors })
            {
                StatusCode = response.StatusCode
            };
        }
        [HttpPost("refresh-token-login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Auths, ActionType = ActionType.Writing, Definition = "refresh token login action")]
        public async Task<IActionResult> RefreshTokenLogin(RefreshTokenLoginCommandRequest refreshTokenLoginCommandRequest)
        {

            RefreshTokenLoginCommandResponse response = await _mediator.Send(refreshTokenLoginCommandRequest);

            return new JsonResult(response.Success
                ? new { token = response.Token }
                : new { errors = response.Errors })
            {
                StatusCode = response.StatusCode
            };
        }


        [HttpPost("google-login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Auths, ActionType = ActionType.Writing, Definition = "user login with google action")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandResponse response = await _mediator.Send(googleLoginCommandRequest);
            return Ok(response);
        }

        [HttpPost("facebook-login")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Auths, ActionType = ActionType.Writing, Definition = "user login with facebook action")]
        public async Task<IActionResult> FacebookLogin()
        {
            return Ok();
        }
    }

}
 