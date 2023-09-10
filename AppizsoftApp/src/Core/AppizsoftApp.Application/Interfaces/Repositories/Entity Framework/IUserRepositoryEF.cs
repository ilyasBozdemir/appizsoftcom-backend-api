using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces.Repositories.Entity_Framework
{
    /// <summary>
    /// Kullanıcı verilerini yönetmek için özelleştirilmiş IRepository arabirimini temsil eder.
    /// </summary>
    public interface IUserRepositoryEF : IRepository<User>
    {
        /// <summary>
        /// Belirli bir e-posta adresine sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="email">Aranan kullanıcının e-posta adresi.</param>
        /// <returns>Eşleşen kullanıcı, eğer varsa; aksi takdirde null.</returns>
        /// 

        User GetUserByEmail(string email); //örnek olarak  IRepository ile  IUserRepository özelleştiriliyor.

        // Diğer kullanıcı yönetimi işlevleri burada tanımlanabilir.
    }

}
