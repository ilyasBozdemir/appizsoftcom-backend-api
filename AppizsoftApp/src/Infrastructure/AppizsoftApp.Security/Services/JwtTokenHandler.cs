using AppizsoftApp.Application.Dtos;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppizsoftApp.Security.Services
{
    public class JwtTokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private IConfigurationSection jwtSettings;
        private string secretKey;
        private string issuer;
        private string audience;
        private string accessTokenExpirationMinutes;


        public JwtTokenHandler(IConfiguration configuration, TokenValidationParameters tokenValidationParameters, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _tokenValidationParameters = tokenValidationParameters;
            _httpContextAccessor = httpContextAccessor;
        }

        public Token GenerateToken(AppUser user)
        {

            jwtSettings = _configuration.GetSection("JwtSettings");
            secretKey = jwtSettings["SecretKey"] ?? "";
            issuer = jwtSettings["Issuer"] ?? ""; ;
            audience = jwtSettings["Audience"] ?? "";
            accessTokenExpirationMinutes = jwtSettings["AccessTokenExpirationMinutes"] ?? "";

            var tokenHandler = new JwtSecurityTokenHandler();

            var claims = GenerateUserClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var expiry = DateTime.Now.AddMinutes(int.Parse(accessTokenExpirationMinutes ?? string.Empty));

            var token = new JwtSecurityToken(issuer, audience, claims, expires: expiry, signingCredentials: signIn);

            return new()
            {
                AccessToken = tokenHandler.WriteToken(token),
                Expiration = expiry,
            };
        }

        public Claim[] GenerateUserClaims(AppUser user)
        {
            //Roles role = (Roles)user.RoleId;
            Roles role = (Roles)1;
            string roleAsString = role.ToString();

            return new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["JwtSettings:Subject"]),
            new Claim(JwtRegisteredClaimNames.Iss, _configuration["JwtSettings:Issuer"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, roleAsString)
        };
        }


        public bool ValidateToken(string token)
        {
            if (token == null)
                return false;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                return true;
            }
            catch
            {
                return false;
            }

        }

        public IEnumerable<Claim> GetClaimsFromJwt(string jwtToken)
        {
            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(jwtToken);
            return jwt.Claims;
        }

        public IEnumerable<Claim> GetClaimsFromHttpContext()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext != null)
            {
                var authorizationHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

                if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
                {
                    var jwtToken = authorizationHeader.Substring("Bearer ".Length);

                    return GetClaimsFromJwt(jwtToken);
                }
            }

            return new List<Claim>();

        }
    }
}
