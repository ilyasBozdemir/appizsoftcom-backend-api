using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Dtos.User;

namespace AppizsoftApp.Application.Interfaces.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);

        Task<Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
