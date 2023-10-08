using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<Dtos.Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<Dtos.Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
