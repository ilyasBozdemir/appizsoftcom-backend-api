using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Helpers;

namespace AppizsoftApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse : ActionResult 
    {
        public LoginUserCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors) { }

        public LoginUserCommandResponse(bool success, int statusCode = 200)
            : base(success, statusCode) { }
        public LoginUserCommandResponse() { }

        public Token Token { get; set; }

    }
}
