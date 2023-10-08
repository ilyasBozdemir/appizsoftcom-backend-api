using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Domain.Entities.Identity;
using System.Security.Claims;

namespace AppizsoftApp.Application.Interfaces.Services
{
    public interface ITokenHandler
    {
        Token GenerateToken(AppUser user);
        bool ValidateToken(string token);
        IEnumerable<Claim> GetClaimsFromJwt(string jwtToken);
        IEnumerable<Claim> GetClaimsFromHttpContext();
    }
}
