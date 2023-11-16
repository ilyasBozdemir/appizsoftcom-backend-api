using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Exceptions;
using AppizsoftApp.Application.Features.Commands.AppUser.LoginUser;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;

namespace AppizsoftApp.Application.Features.Commands.AppUser.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommandRequest, RefreshTokenLoginCommandResponse>
    {
        private readonly IAuthService _authService;
        public RefreshTokenLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<RefreshTokenLoginCommandResponse> Handle(RefreshTokenLoginCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
                return new()
                {
                    Token = token,
                    StatusCode = 200
                };
            } 

            catch (UserNotFoundException ex)
            {
                var errors = new string[] { ex.Message };

                return new RefreshTokenLoginCommandResponse(false, 404, errors);
            }
            catch (Exception ex)
            {
                var errors = new string[] { ex.Message };

                return new RefreshTokenLoginCommandResponse(false, 500, errors);
            }

        }
    }
}
