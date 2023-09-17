﻿using AppizsoftApp.Application.Dtos.Auth;
using AppizsoftApp.Application.Dtos.User;
using AppizsoftApp.Domain.Entities;
using AppizsoftApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace AppizsoftApp.Persistence.Repositories.Entity_Framework
{
    /// <summary>
    /// Entity Framework kullanarak kullanıcı verilerini yönetmek için özelleştirilmiş bir IRepository uygulamasıdır.
    /// </summary>
    public class EfAuthRepository : AuthRepository
    {
        private readonly AppizsoftAppDBContext _context;
        public EfAuthRepository(AppizsoftAppDBContext context):base(context)
        {
            _context = context;
        }
        public async Task<User> Login(string userName, string password)
        {
           return await base.Login(userName, password);
        }

        public async Task<User> Register(User user, string password)
        {
            return await base.Register(user, password);
        }

        public async Task<bool> UserExists(string userName)
        {
            return await base.UserExists(userName);
        }
    }

}
