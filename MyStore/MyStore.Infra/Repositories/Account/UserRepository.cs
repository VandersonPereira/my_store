﻿using MyStore.Domain.Account.Entities;
using MyStore.Domain.Account.Repositories;
using MyStore.Domain.Account.Specs;
using MyStore.Infra.ORM.Contexts;
using System.Linq;

namespace MyStore.Infra.Repositories.Account
{
    public class UserRepository : IUserRepository
    {
        private readonly MyStoreDataContext _context;

        public UserRepository(MyStoreDataContext context)
        {
            _context = context;
        }

        public User GetByAuthorizationCode(string authorizationCode)
        {
            return _context
                .Users
                .Where(UserSpecs.GetByAuthorizationCode(authorizationCode))
                .FirstOrDefault();
        }

        public User GetByUserName(string userName)
        {
            return _context
                .Users
                .Where(UserSpecs.GetByUserName(userName))
                .FirstOrDefault();
        }

        public void Save(User user)
        {
            _context.Users.Add(user);
        }

        public void Update(User user)
        {
            _context.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
