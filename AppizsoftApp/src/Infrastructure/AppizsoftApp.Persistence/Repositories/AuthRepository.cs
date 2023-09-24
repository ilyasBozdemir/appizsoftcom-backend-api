using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Application.Interfaces.Services;
using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppizsoftApp.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private AppizsoftAppDBContext _context;
        private readonly IPasswordService _passwordService;

        public AuthRepository(AppizsoftAppDBContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task<User> Login(string Email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x =>  x.Email == Email);

            if(user == null)
            {
                return null;
            }

            if(!_passwordService.VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }
            return user;

        }

        public async Task<bool> UserExists(string mailAddress)
        {
            // Kullanıcı  veritabanında mevcut mu kontrol et
            return await _context.Users.AnyAsync(x => x.Email == mailAddress);
        }

        public async Task<User> Register(User user, string password)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }

}
