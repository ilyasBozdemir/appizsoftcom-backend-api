using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Features.Commands.AppUser.RefreshTokenLogin
{
   
    public class RefreshTokenLoginCommandResponse : ActionResult
    {
        public RefreshTokenLoginCommandResponse(bool success, int statusCode, string[] errors = null)
        : base(success, statusCode, errors) { }

        public RefreshTokenLoginCommandResponse(bool success, int statusCode = 200)
            : base(success, statusCode) { }
        public RefreshTokenLoginCommandResponse() { }

        public Token Token { get; set; }

    }
}
