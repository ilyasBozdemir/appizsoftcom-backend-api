using AppizsoftApp.Application.Interfaces.Services;
using MediatR;

namespace AppizsoftApp.Application.Features.Commands.LoginUser
{
    /// <summary>
    /// Kullanıcının oturum açma komutunu işleyen işlemci sınıfı.
    /// </summary>
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// LoginUserCommandHandler sınıfının yapıcı metodu.
        /// </summary>
        /// <param name="authService">Kimlik doğrulama hizmetini temsil eden servis.</param>
        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Kullanıcının oturum açma komutunu işler ve yanıtı döndürür.
        /// </summary>
        /// <param name="request">Oturum açma komutu isteği.</param>
        /// <param name="cancellationToken">İptal belirteci.</param>
        /// <returns>Oturum açma işlemi sonucunu temsil eden yanıt.</returns>
        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            return await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
        }
    }
}
