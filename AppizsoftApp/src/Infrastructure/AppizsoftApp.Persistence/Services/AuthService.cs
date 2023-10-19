using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Dtos.Facebook;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using AppizsoftApp.Application.Helpers;
using AppizsoftApp.Application.Features.Commands.CreateUser;
using System.Security.Claims;
using AppizsoftApp.Application.Interfaces.Services.Authentications;
using AppizsoftApp.Application.Dtos.User;

namespace AppizsoftApp.Persistence.Services
{
    /*
    _signInManager.CheckPasswordSignInAsync yöntemi, sadece kullanıcının kimliğini doğrular ve oturum açma işlemi gerçekleştirmez. Dolayısıyla, kullanıcı kimlik doğrulama başarılı olsa bile oturum açılmaz.
    Eğer oturum açmayı gerçekleştirmek istiyorsanız,
    _signInManager.PasswordSignInAsync yöntemini kullanmalısınız.
    Bu yöntem, kullanıcının kimliğini doğruladığı gibi oturum açmayı da sağlar.
    Önceki açıklamalara göre, _signInManager.PasswordSignInAsync yöntemi ile kullanıcı kimliği doğrulama ve oturum açma işlemini gerçekleştirebilirsiniz.
     */

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;


        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;

        public AuthService(HttpClient httpClient = null, IConfiguration configuration = null, ITokenHandler tokenHandler = null, IUserService userService = null, IMailService mailService = null, UserManager<AppUser> userManager = null, SignInManager<AppUser> signInManager = null)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _userService = userService;
            _mailService = mailService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Token> HandleExternalLoginAsync(ExternalLoginInfo info, int accessTokenLifeTime = 900)
        {
            if (info == null)
            {
                throw new Exception("External login info is missing.");
            }

            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            switch (result)
            {
                case { Succeeded: true }:
                    var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                    var token = _tokenHandler.GenerateToken(user);
                    return token;

                case { IsLockedOut: true }:
                    throw new Exception("User account is locked.");

                case { IsNotAllowed: true }:
                    throw new Exception("User is not allowed to sign in.");

                default:
                    throw new Exception("Unhandled result case.");
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var newUser = new AppUser
            {
                UserName = email,
                Email = email,

            };
            var identityResult = await _userManager.CreateAsync(newUser);

            if (identityResult.Succeeded)
            {
                await _userManager.AddLoginAsync(newUser, info);
                var token = _tokenHandler.GenerateToken(newUser);
                return token;
            }
            else
                throw new Exception("User registration failed.");

        }


        private async Task<IdentityResult> CreateUserAsync(AppUser user, CreateUserCommandRequest registerUser, UserLoginInfo info = null, int accessTokenLifeTime = 900)
        {
            bool isExternalRegistration = user != null;

            if (!isExternalRegistration)
            {
                user = await _userManager.FindByEmailAsync(registerUser.Email);
                if (user == null)
                {
                    user = new AppUser
                    {
                        Id = Guid.NewGuid(),
                        Email = registerUser.Email,
                        UserName = registerUser.UserName,
                        Name = registerUser.Name,
                        Surname = registerUser.Surname,
                        CreatedAt = DateTime.UtcNow
                    };
                    var identityResult = await _userManager.CreateAsync(user);

                    isExternalRegistration = identityResult.Succeeded;
                }
            }

            if (isExternalRegistration)
            {
                await _userManager.AddLoginAsync(user, info);

                Token token = _tokenHandler.GenerateToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return IdentityResult.Success;
            }
            throw new Exception("Invalid registration.");
        }




        public Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task ForgotPasswordAsync(string usernameOrEmail)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task<CreateUserResponse> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task PasswordResetAsnyc(string usernameOrEmail)
        {
            throw new NotImplementedException();
        }

        public Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateUserResponse> CreateUserAsync(CreateUser createUser)
        {
            var commandResponse = new CreateUserResponse();
            return commandResponse;
        }

        public Task ResetPasswordAsync(string usernameOrEmail, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> SignInAsync(string username, string password, bool isPersistent, bool lockoutOnFailure)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CheckUserExistence(string userName, string email)
        {
            
            var userByName = await _userManager.FindByNameAsync(userName);

            var userByEmail = await _userManager.FindByEmailAsync(email);

            if (userByName != null || userByEmail != null)
                return true;

            return false;
        }
    }
}
