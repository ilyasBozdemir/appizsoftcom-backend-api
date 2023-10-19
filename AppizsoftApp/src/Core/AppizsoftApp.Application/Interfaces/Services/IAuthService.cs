using AppizsoftApp.Application.Interfaces.Services.Authentications;
using Microsoft.AspNetCore.Identity;

namespace AppizsoftApp.Application.Interfaces.Services
{
    public interface IAuthService : IExternalAuthentication, IInternalAuthentication
    { 
        Task PasswordResetAsnyc(string usernameOrEmail);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
        Task ForgotPasswordAsync(string usernameOrEmail);
        Task ResetPasswordAsync(string usernameOrEmail, string resetToken, string newPassword);


        Task<SignInResult> SignInAsync(string username, string password, bool isPersistent, bool lockoutOnFailure);
        Task SignOutAsync();
        Task<bool> CheckUserExistence(string userName, string email);
    }
}
