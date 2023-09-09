using AppizsoftApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces
{
    /// <summary>
    /// User verilerine erişim sağlayan IRepository arayüzü.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Verilen kullanıcı kimliğine sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="id">Kullanıcı kimliği.</param>
        /// <returns>Kullanıcı nesnesi.</returns>
        Task<User> GetByIdAsync(Guid id);

        /// <summary>
        /// Tüm kullanıcıları getirir.
        /// </summary>
        /// <returns>Kullanıcı koleksiyonu.</returns>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// Yeni bir kullanıcı ekler.
        /// </summary>
        /// <param name="user">Eklenen kullanıcı nesnesi.</param>
        Task AddAsync(User user);

        /// <summary>
        /// Var olan bir kullanıcıyı günceller.
        /// </summary>
        /// <param name="user">Güncellenen kullanıcı nesnesi.</param>
        Task UpdateAsync(User user);

        /// <summary>
        /// Verilen kullanıcı kimliğine sahip kullanıcıyı siler.
        /// </summary>
        /// <param name="id">Kullanıcı kimliği.</param>
        Task DeleteAsync(Guid id);
    }
}

