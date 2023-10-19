using AppizsoftApp.Application.Constants;
using AppizsoftApp.Application.CustomAttributes;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Features.Commands.CreateUser;
using AppizsoftApp.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v1
{
    [Route("api/user")]
    [ApiVersion("1")]
    [ApiController]
    public class UsersController : BaseController
    {

        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-user")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Auths, ActionType = ActionType.Writing, Definition = "create user actions")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest registerUserCommandRequest)
        {
            CreateUserCommandResponse commandResponse = await _mediator.Send(registerUserCommandRequest);

            return new JsonResult(commandResponse.Success
                ? new { data = commandResponse.Data }
                : new { errors = commandResponse.Errors })
            {
                StatusCode = commandResponse.StatusCode
            };

        }
    }
}
