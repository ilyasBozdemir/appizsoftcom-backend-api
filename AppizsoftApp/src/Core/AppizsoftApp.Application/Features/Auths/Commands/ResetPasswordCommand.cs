using AppizsoftApp.Application.Features.Auths.Results;
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
        public string NewPassword { get; set; }
    }
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResult>
    {
        // Bu işleyici, gerçek şifre sıfırlama mantığını burada uygular
        public async Task<ResetPasswordResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            // TODO: Token'in geçerliliğini kontrol et
            // TODO: Kullanıcının şifresini sıfırla



            // Başarı durumunu döndür
            return new ResetPasswordResult()
            {
                Success = true,
                Message = "",
            };
        }
    }
}
