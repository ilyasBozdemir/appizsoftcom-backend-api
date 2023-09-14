using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Application.Exceptions.UserExceptions;
using AppizsoftApp.Application.Features.Users.Queries;
using AppizsoftApp.WebApi.Controllers.v1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    public class AuthController : ApiControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator) : base(mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("register")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> RegisterUserV1([FromBody] UserForRegisterDto user)
        {
            try
            {
                var query = new ExistUserQuery { UserId = user.Id };
                var userExists = await _mediator.Send(query);
                if (user == null)
                {
                    return BadRequest("İstek geçersiz veya eksik parametreler içeriyor.Hata Kodu: EmptyUserException");
                }
                else
                {
                    if (userExists)
                    {
                        throw new UserAlreadyExistsException($"Kullanıcı zaten mevcut: {user.Id}");
                    }
                    else
                    {
                        return StatusCode(201, new
                        {
                            Message = "Yeni kullanıcı başarıyla oluşturuldu.",
                        });
                    }
                }

            }
            catch (UserNotFoundException ex)
            {
                return BadRequest(new
                {
                    error = ex.Message,//BadRequest 400 hata kodunu döndürür 
                });
            }
            catch (UserAlreadyExistsException ex)
            {
                return Conflict(
                    new
                    {
                        error = ex.Message,//Conflict 409 hata kodunu döndürür 
                    }
                );

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Beklenmeyen bir hata oluştu. hata: {ex.Message}");
                
            }
        }
    }
}
