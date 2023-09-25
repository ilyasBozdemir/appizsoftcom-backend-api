using AppizsoftApp.Domain.Entities;
using System.Security.Claims;

namespace AppizsoftApp.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
        IEnumerable<Claim> GetClaimsFromJwt(string jwtToken);
        IEnumerable<Claim> GetClaimsFromHttpContext();
    }
}
