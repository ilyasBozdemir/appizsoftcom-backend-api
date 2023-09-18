using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppizsoftApp.Persistence.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private AppizsoftAppDBContext _context;
        public AuthRepository(AppizsoftAppDBContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == userName);

            if(user == null)
            {
                return null;
            }

            if(!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                return null;
            }
            return user;

        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!= userPasswordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
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
