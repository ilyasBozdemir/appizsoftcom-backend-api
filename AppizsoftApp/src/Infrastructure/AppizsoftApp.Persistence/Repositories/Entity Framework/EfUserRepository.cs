using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Application.Interfaces.Repositories;
using AppizsoftApp.Application.Interfaces.Repositories.Entity_Framework;
using AppizsoftApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppizsoftApp.Persistence.Repositories.Entity_Framework
{
    /// <summary>
    /// Entity Framework kullanarak kullanıcı verilerini yönetmek için özelleştirilmiş bir IRepository uygulamasıdır.
    /// </summary>
    public class EfUserRepository : EfBaseRepository<User>, IUserRepositoryEF
    {
        public EfUserRepository(DbContext dbContext) : base(dbContext)
        {
            // EfRepository'nin kurucu metodunu çağırın.
        }

        public Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task Update(User entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IBaseRepository<User>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IBaseRepository<User>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

      
    }

}
