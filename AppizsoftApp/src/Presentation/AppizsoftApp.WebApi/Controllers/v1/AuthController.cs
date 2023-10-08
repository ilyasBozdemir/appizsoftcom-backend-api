using AppizsoftApp.Application.Features.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppizsoftApp.WebApi.Controllers.v1
{
    /// <summary>
    /// Kimlik doğrulama ve oturum yönetimi işlemlerini yöneten API kontrolcüsü.
    /// </summary>
    [Route("api/v1/auth")]
    [ApiVersion("1")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// AuthController sınıfının yapıcı metodu. 
        /// </summary>
        /// <param name="mediator">Mediator servisini enjekte etmek için kullanılır.</param>
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Kullanıcının oturum açma işlemini gerçekleştirir.
        /// </summary>
        /// <param name="loginUserCommandRequest">Oturum açma isteği.</param>
        /// <returns>Oturum açma işlemi sonucunda dönen yanıt.</returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandResponse response = await _mediator.Send(loginUserCommandRequest);
            return Ok(response);
        }
    }
}
