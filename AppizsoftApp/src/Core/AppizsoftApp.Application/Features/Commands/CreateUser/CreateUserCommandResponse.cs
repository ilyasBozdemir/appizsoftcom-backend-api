using AppizsoftApp.Application.Helpers;

namespace AppizsoftApp.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandResponse : ActionResult
    {
        public CreateUserCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors) { }

        public CreateUserCommandResponse(bool success, int statusCode = 200)
            : base(success, statusCode) { }
        public CreateUserCommandResponse() { }

    }
}
