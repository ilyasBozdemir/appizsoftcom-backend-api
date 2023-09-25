using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Commands
{
    public class ResetPasswordCommand : IRequest<ResetPasswordResult>
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResult>
    {
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;
        public ResetPasswordCommandHandler(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }

        public async Task<ResetPasswordResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var tokenIsValid = _tokenService.ValidateToken(request.Token);
            if (!tokenIsValid)
            {
                return new ResetPasswordResult()
                {
                    Success = false,
                    Message = "Geçersiz token veya kullanıcı.",
                };
            }

            return await _authRepository.UpdatePassword(request.Email, request.CurrentPassword, request.NewPassword);

        }
    }
}
