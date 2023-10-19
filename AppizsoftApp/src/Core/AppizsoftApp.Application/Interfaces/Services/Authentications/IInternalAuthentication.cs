using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Application.Features.Commands.CreateUser;

namespace AppizsoftApp.Application.Interfaces.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<CreateUserResponse> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);

        Task<Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
