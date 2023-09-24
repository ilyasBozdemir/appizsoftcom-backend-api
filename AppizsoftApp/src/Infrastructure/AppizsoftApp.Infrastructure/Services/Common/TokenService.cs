using AppizsoftApp.Application.Configurations;
using AppizsoftApp.Application.Enums;
using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppizsoftApp.Infrastructure.Services.Common
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        private IConfigurationSection jwtSettings;
        private string secretKey;
        private string issuer;
        private string audience;
        private string accessTokenExpirationMinutes;


        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            jwtSettings = _configuration.GetSection("JwtSettings");

            secretKey = jwtSettings["SecretKey"];
            issuer = jwtSettings["Issuer"];
            audience = jwtSettings["Audience"];
            accessTokenExpirationMinutes = jwtSettings["AccessTokenExpirationMinutes"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = GenerateUserClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var expiry = DateTime.Now.AddMinutes(int.Parse(accessTokenExpirationMinutes ?? string.Empty));

            var token = new JwtSecurityToken(issuer,
                audience, claims, expires: expiry, signingCredentials: signIn);

            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }

        private Claim[] GenerateUserClaims(User user)
        {
            Roles role = (Roles)user.RoleId;
            string roleAsString = role.ToString();

            return new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["JwtSettings:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Email", user.Email),
                    new Claim("Role", roleAsString),
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

        public string RefreshToken(string email)
        {
            return "";
        }
    }
}
