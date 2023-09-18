using AppizsoftApp.Domain.Entities;

namespace AppizsoftApp.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string RefreshToken(string email);
        bool ValidateToken(string token);
    }
}
