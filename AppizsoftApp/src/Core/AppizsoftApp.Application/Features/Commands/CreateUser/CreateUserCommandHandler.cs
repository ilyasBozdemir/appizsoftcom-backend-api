using AppizsoftApp.Application.Exceptions;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;
namespace AppizsoftApp.Application.Features.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public CreateUserCommandHandler(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool userExists = await _authService.CheckUserExistence(request.UserName, request.Email);
               
                if (userExists)
                {
                    throw new UserAlreadyExistsException("Kullanıcı zaten kayıtlı. Hata Kodu : 409");
                }


                var createUserResponse = await _userService.CreateAsync(new Dtos.User.CreateUser()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Name = request.Name,
                    Surname = request.Surname,
                    Password = request.Password,
                });

                var commandResponse = new CreateUserCommandResponse(createUserResponse.Succeeded, 201);
                commandResponse.Data = createUserResponse;

                return commandResponse;
            }
            catch (UserAlreadyExistsException ex)
            {
                var errors = new string[] { ex.Message };
                return new CreateUserCommandResponse(false, 409, errors);
            }

            catch (Exception ex)
            {
                var errors = new string[] { ex.Message };

                return new CreateUserCommandResponse(false, 400, errors);
            }
        }
    }

}
