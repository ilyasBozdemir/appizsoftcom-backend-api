
using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Features.AppUser.Results;
using AppizsoftApp.Domain.Entities;

namespace AppizsoftApp.Application.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string mailAddress);
        Task<ResetPasswordResult> UpdatePassword(string email, string currentPassword, string newPassword);
    }
}
