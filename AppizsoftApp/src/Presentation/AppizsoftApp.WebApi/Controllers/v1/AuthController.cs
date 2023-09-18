using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Exceptions.AuthExceptions;
using AppizsoftApp.Application.Features.Auths.Commands;
using AppizsoftApp.Application.Features.Auths.Queries;
using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Results;
using AppizsoftApp.Application.Validators.Auths;
using AppizsoftApp.WebApi.Controllers.v1;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AppizsoftApp.WebApi.Controllers
{
    /// <summary>
    /// register user
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     POST /api/v1/auth/register
    /// </remarks>
    /// <param name="user">user of User</param>
    /// <returns>User information</returns>
    /// 
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v1/auth")]
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize]
    public class AuthController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        [HttpPost("register")]
        [ProducesResponseType(typeof(ResponseResult<CreateUserResult>), 201)]
        [ProducesResponseType(typeof(ResponseResult<CreateUserResult>), 400)]
        [ProducesResponseType(typeof(ResponseResult<CreateUserResult>), 404)]
        [ProducesResponseType(typeof(ResponseResult<CreateUserResult>), 500)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserV1([FromBody] UserForRegisterDto userForRegister, CancellationToken cancellationToken)
        {
            try
            {
                var validator = new UserForRegisterDtoValidator();
                var validationResult = validator.Validate(userForRegister);

                if (!validationResult.IsValid)
                {
                    var errors = validationResult.Errors.Select(e => e.ErrorMessage);
                    return new JsonResult(new { errors = errors })
                    {
                        StatusCode = 400
                    };
                }

                var createUserCommandDto = _mapper.Map<CreateUserCommand>(userForRegister);
                var createUserResult = await _mediator.Send(createUserCommandDto, cancellationToken);
                if (createUserResult.StatusCode == (int)HttpStatusCode.Created)
                {
                    return new JsonResult(new { message = createUserResult.Message, user = createUserResult.User })
                    {
                        StatusCode = createUserResult.StatusCode
                    };
                }
                else
                {
                    return new JsonResult(new { error = createUserResult.Message })
                    {
                        StatusCode = createUserResult.StatusCode
                    };
                }
            }
            catch (EmptyUserException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Beklenmeyen bir hata oluştu. hata: {ex.Message}");
            }
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseResult<LoginResult>), 200)]
        [ProducesResponseType(typeof(ResponseResult<LoginResult>), 400)]
        [ProducesResponseType(typeof(ResponseResult<LoginResult>), 404)]
        [ProducesResponseType(typeof(ResponseResult<LoginResult>), 500)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUserV1([FromBody] UserForLoginDto user)
        {
            try
            {
                var loginCommand = new LoginCommand
                {
                    UserName = user.UserName,
                    Password = user.Password
                };

                var loginResult = await _mediator.Send(loginCommand);

                if (loginResult.StatusCode == (int)HttpStatusCode.OK)
                {
                    return new JsonResult(new {  token = loginResult.Token})
                    {
                        StatusCode = loginResult.StatusCode
                    };
                }
                else
                {
                    return new JsonResult(new { error = loginResult.Message })
                    {
                        StatusCode = loginResult.StatusCode
                    };
                }
            }
            catch (UserNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Beklenmeyen bir hata oluştu. hata: {ex.Message}");
            }
         
        }

        [HttpPost("logout/{user}")]
        [ProducesResponseType(typeof(ResponseResult<LoginResult>), 200)]
        public async Task<IActionResult> LogoutUserV1([FromBody] UserForLogoutDto user)
        {
            return Ok(user);
        }

        [HttpPost("checksession")]
        [AllowAnonymous]
        public async Task<IActionResult> CheckSession([FromBody] UserForSessionCheckDto model)
        {
            var checkSessionQuery = new CheckSessionQuery
            {
                Token = model.Token
            };

            var sessionValid = await _mediator.Send(checkSessionQuery);

            if (sessionValid)
            {
                return Ok(new { Message = "Oturum hala geçerli." });
            }

            return Unauthorized(new { Message = "Oturum süresi dolmuş veya geçersiz token." });
        }



        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPasswordV1(UserForForgotPasswordDto user)
        {
            return Ok();
        }
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPasswordV1(UserForResetPasswordDto user)
        {
            return Ok();
        }

    }
}

