using AppizsoftApp.Application.Features.Auths.Results;
using MediatR;

namespace AppizsoftApp.Application.Features.Auths.Queries
{
    public class ForgotPasswordQuery : IRequest<ForgotPasswordResult>
    {
        public string Email { get; set; }
    }
    public class ForgotPasswordQueryHandler : IRequestHandler<ForgotPasswordQuery, ForgotPasswordResult>
    {
      
        public ForgotPasswordQueryHandler()
        {
           
        }

        public async Task<ForgotPasswordResult> Handle(ForgotPasswordQuery request, CancellationToken cancellationToken)
        {
            return new ForgotPasswordResult
            {
                IsSuccessful = false,
                ErrorMessage = "Belirtilen e-posta adresiyle ilişkilendirilmiş bir hesap bulunamadı."
            };
        }

    }

}
