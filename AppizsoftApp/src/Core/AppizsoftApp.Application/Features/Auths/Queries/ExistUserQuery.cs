using AppizsoftApp.Application.Exceptions.AuthExceptions;
using AppizsoftApp.Application.Features.Auths.Results;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Application.Wrappers;
using AppizsoftApp.Domain.Entities;
using MediatR;
using System.Net;

namespace AppizsoftApp.Application.Features.Users.Queries
{
    public class ExistUserQuery : IRequest<ExistUserResult>
    {
        public string UserName { get; set; }
    }
    public class ExistUserQueryHandler : IRequestHandler<ExistUserQuery, ExistUserResult>
    {
        
        private readonly IAuthRepository _authRepository;
        public ExistUserQueryHandler(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        

        public async Task<ExistUserResult> Handle(ExistUserQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _authRepository.UserExists(request.UserName);

            if (result)
            {
                return new ExistUserResult
                {
                    UserExists = result
                };
            }
            else
            {
                return new ExistUserResult
                {
                    UserExists = false
                };
            }
            
        }
    }
}
