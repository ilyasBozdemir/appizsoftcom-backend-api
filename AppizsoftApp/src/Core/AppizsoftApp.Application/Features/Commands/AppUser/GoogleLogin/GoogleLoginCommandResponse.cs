using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Helpers;

namespace AppizsoftApp.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandResponse : ActionResult
    {
        public GoogleLoginCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors) { }

        public GoogleLoginCommandResponse(bool success, int statusCode = 200)
            : base(success, statusCode) { }
        public GoogleLoginCommandResponse() { }

        public Token Token { get; set; }

    }
}
