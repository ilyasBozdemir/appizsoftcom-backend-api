
using AppizsoftApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Application.Interfaces.Repositories.Dapper
{
    public interface IUserRepositoryDapper : IUserRepository
    {
        User GetUserByEmail(string email);
        // Diğer kullanıcı yönetimi işlevleri
    }
}
