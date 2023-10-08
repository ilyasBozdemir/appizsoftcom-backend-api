using MediatR;

namespace AppizsoftApp.Application.Features.Commands.LoginUser
{
    /// <summary>
    /// Kullanıcının oturum açma isteği için kullanılan istemci tarafından gönderilen veri modeli.
    /// </summary>
    public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
    {
        /// <summary>
        /// Kullanıcı adı veya e-posta adresi.
        /// </summary>
        public string UsernameOrEmail { get; set; }

        /// <summary>
        /// Kullanıcının şifresi.
        /// </summary>
        public string Password { get; set; }
    }

}
