using AppizsoftApp.Application.Exceptions;
using AppizsoftApp.Application.Features.Commands.AppUser.CreateUser;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;

namespace AppizsoftApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;
        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);

                return new LoginUserCommandResponse(true, 201)
                {
                    Token = token
                };

            }
            catch (AuthenticationErrorException ex)
            {
                var errors = new string[] { ex.Message };
                return new LoginUserCommandResponse(false, 401, errors);
            }
            catch (UserNotFoundException ex)
            {
                var errors = new string[] { ex.Message };

                return new LoginUserCommandResponse(false, 404, errors);
            }
            catch (Exception ex)
            {
                var errors = new string[] { ex.Message };

                return new LoginUserCommandResponse(false, 500, errors);
            }
        }
    }
}
