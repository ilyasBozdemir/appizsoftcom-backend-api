using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Interfaces.Repositories;
using MediatR;

namespace AppizsoftApp.Application.Features.Auths.Queries
{
    public class VerifyEmailQuery : IRequest<VerifyEmailResult>
    {
        public string Token { get; set; }
        public string Email { get; set; }
    }
    public class VerifyEmailQueryHandler : IRequestHandler<VerifyEmailQuery, VerifyEmailResult>
    {
        
        public VerifyEmailQueryHandler()
        {
           
        }

        public async Task<VerifyEmailResult> Handle(VerifyEmailQuery request, CancellationToken cancellationToken)
        {
            return new VerifyEmailResult
            {
                IsSuccessful = true,
                Message = "E-posta adresiniz başarıyla doğrulandı."
            };
        }
    }


}
