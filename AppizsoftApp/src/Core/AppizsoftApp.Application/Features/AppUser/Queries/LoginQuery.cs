using AppizsoftApp.Application.Features.AppUser.Results;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.AppUser.Queries
{
    public class LoginQuery : IRequest<LoginResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginResult>
    {
        public LoginQueryHandler()
        {
          
        }
        public async Task<LoginResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            Task.Delay(500).Wait();

            return new LoginResult
            {
              
            };
        }
    }

}
