using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;
namespace AppizsoftApp.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var token2 = await _authService.GoogleLoginAsync(request.IdToken, 900);
                Token token = new() 
                {
                    AccessToken=null,
                };
                return new()
                {
                    Token = token
                };
            }
            catch (Exception)
            {

                throw;
            }


           
        }
    }
}
