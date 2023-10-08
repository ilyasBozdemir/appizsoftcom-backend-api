using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Dtos.Facebook;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppizsoftApp.Application.Features.Commands.LoginUser;

namespace AppizsoftApp.Persistence.Services
{
    public class AuthService: IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ITokenHandler _tokenHandler;
        private readonly IUserService _userService;
        private readonly IMailService _mailService;
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private  readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;


        public AuthService(IHttpClientFactory httpClientFactory, IConfiguration configuration, UserManager<Domain.Entities.Identity.AppUser> userManager,
            ITokenHandler tokenHandler,
            SignInManager<AppUser> signInManager, IMailService mailService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
            _tokenHandler = tokenHandler;
            _signInManager = signInManager;
            _mailService = mailService;
        }

        async Task<Token> CreateUserExternalAsync(AppUser user, string email, string name, UserLoginInfo info, int accessTokenLifeTime)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid(),
                        Email = email,
                        UserName = email,
                        NameSurname = name
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

                Token token = _tokenHandler.GenerateToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }



        public async Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            string accessTokenResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/oauth/access_token?client_id={_configuration["ExternalLoginSettings:Facebook:Client_ID"]}&client_secret={_configuration["ExternalLoginSettings:Facebook:Client_Secret"]}&grant_type=client_credentials");

            FacebookAccessTokenResponse? facebookAccessTokenResponse = JsonSerializer.Deserialize<FacebookAccessTokenResponse>(accessTokenResponse);

            string userAccessTokenValidation = await _httpClient.GetStringAsync($"https://graph.facebook.com/debug_token?input_token={authToken}&access_token={facebookAccessTokenResponse?.AccessToken}");

            FacebookUserAccessTokenValidation? validation = JsonSerializer.Deserialize<FacebookUserAccessTokenValidation>(userAccessTokenValidation);

            if (validation?.Data.IsValid != null)
            {
                string userInfoResponse = await _httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=email,name&access_token={authToken}");

                FacebookUserInfoResponse? userInfo = JsonSerializer.Deserialize<FacebookUserInfoResponse>(userInfoResponse);

                var info = new UserLoginInfo("FACEBOOK", validation.Data.UserId, "FACEBOOK");
                Domain.Entities.Identity.AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                return await CreateUserExternalAsync(user, userInfo.Email, userInfo.Name, info, accessTokenLifeTime);
            }
            throw new Exception("Invalid external authentication.");
        }

        public async Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task<LoginUserCommandResponse> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task PasswordResetAsnyc(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
