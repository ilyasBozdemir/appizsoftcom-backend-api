using AppizsoftApp.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Auths.Queries
{
    public class CheckSessionQuery : IRequest<bool>
    {
        public string Token { get; set; }
    }
    public class CheckSessionQueryHandler : IRequestHandler<CheckSessionQuery, bool>
    {
        private readonly ITokenService _tokenService;

        public CheckSessionQueryHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<bool> Handle(CheckSessionQuery request, CancellationToken cancellationToken)
        {
            // Token'ı doğrula
            return _tokenService.ValidateToken(request.Token);
        }
    }
}
