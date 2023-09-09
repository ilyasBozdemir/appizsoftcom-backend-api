using AppizsoftApp.Application.Interfaces;
using AppizsoftApp.Domain.Entities;

namespace AppizsoftApp.Infrastructure.Repositories
{
    /// <summary>
    /// User verilerine erişim sağlayan UserRepository sınıfı.
    /// </summary>

    public class UserRepository : IUserRepository 
    {
    
      
        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        // Diğer metotlar için de yorum ekleyin
    }
}
