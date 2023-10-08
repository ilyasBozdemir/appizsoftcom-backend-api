using AppizsoftApp.Application.Interfaces.Services.Authentications;

namespace AppizsoftApp.Application.Interfaces.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    {
        Task PasswordResetAsnyc(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
