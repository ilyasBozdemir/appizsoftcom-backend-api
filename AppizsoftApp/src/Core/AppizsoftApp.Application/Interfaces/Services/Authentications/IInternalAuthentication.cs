using AppizsoftApp.Application.Features.Commands.LoginUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<LoginUserCommandResponse> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime);
        Task<Dtos.Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
