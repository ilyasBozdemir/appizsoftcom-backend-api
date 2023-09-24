using AppizsoftApp.Application.Features.Auths.Queries;
using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Application.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Commands
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcı girişini doğrula
            var user = await _authRepository.Login(request.Email, request.Password);
            if (user == null)
            {
                return new LoginResult
                {
                    StatusCode = 401,
                    Message = "Geçersiz kullanıcı adı veya şifre."
                };
            }

            // Başarılı giriş durumunda bir JWT token oluştur.
            var token = _tokenService.GenerateToken(user);

            return new LoginResult
            {
                StatusCode = 200,
                Token = token
            };
        }
    }

 

}
