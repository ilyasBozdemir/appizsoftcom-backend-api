using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace AppizsoftApp.Application.Features.Auths.Queries
{
    // burası daha işlencektir
    // await _emailService.SendEmailAsync(request.Email, subject, body); kısmı calısmaz çünkü smtp ayarı yapılmadı
    public class ForgotPasswordQuery : IRequest<ForgotPasswordResult> 
    {
        public string Email { get; set; }
    }
    public class ForgotPasswordQueryHandler : IRequestHandler<ForgotPasswordQuery, ForgotPasswordResult>
    {
        private readonly IEmailService _emailService;
        private readonly ITokenService  _tokenService;
        private readonly IAuthRepository _authRepository;
        public ForgotPasswordQueryHandler(IEmailService emailService, ITokenService tokenService, IAuthRepository authRepository)
        {
            _emailService = emailService;
            _tokenService = tokenService;
            _authRepository = authRepository;
        }

        public async Task<ForgotPasswordResult> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var isExistUser = await _authRepository.UserExists(request.Email);
                if (isExistUser)
                {
                    string resetLink = GenerateResetLink(request.Email);
                    string subject = "Şifre Sıfırlama Bağlantısı";
                    string body = $"Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın: {resetLink}";
                    await _emailService.SendEmailAsync(request.Email, subject, body);
                    return new ForgotPasswordResult
                    {
                        IsSuccessful = true,
                        Message = "Sıfırlama bağlantısı gönderildi.",
                    };
                }
                else
                {
                    return new ForgotPasswordResult
                    {
                        IsSuccessful = false,
                        Message = "Belirtilen e-posta adresiyle ilişkilendirilmiş bir hesap bulunamadı.",
                        StatusCode = 404
                    };
                }
            }
            catch (Exception)
            {
                return new ForgotPasswordResult
                {
                    IsSuccessful = false,
                    Message = "Mail gönderilirken hata oluştu.",
                    StatusCode = 500
                };
            }
        }

        private string GenerateResetLink(string email)
        {
             string token = _tokenService.RefreshToken(email);
             return $"https://appizsoft.com/reset-password?token={token}";
        }

    }

}
