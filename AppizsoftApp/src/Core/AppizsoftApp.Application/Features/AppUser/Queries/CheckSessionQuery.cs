using AppizsoftApp.Application.Features.AppUser.Results;
using AppizsoftApp.Application.Interfaces.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.AppUser.Queries
{
    public class CheckSessionQuery : IRequest<CheckSessionResult>
    {
        public string Token { get; set; }
    }
    public class CheckSessionQueryHandler : IRequestHandler<CheckSessionQuery, CheckSessionResult>
    {
        private readonly ITokenService _tokenService;

        public CheckSessionQueryHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<CheckSessionResult> Handle(CheckSessionQuery request, CancellationToken cancellationToken)
        {

            var claimList = _tokenService.GetClaimsFromJwt(request.Token);

            var claimDictionary = claimList.ToDictionary(c => c.Type, c => c.Value);

            var result = new { Claims = claimDictionary };

            return new CheckSessionResult()
            {
                AuthenticateResult= _tokenService.ValidateToken(request.Token),
                Data = result
            };


        }
    }
}
