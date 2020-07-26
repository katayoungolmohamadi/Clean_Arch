using CleanArch.Domain.Interfaces;
using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArch.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        UniversityDBContext _ctx;
        public UserRepository(UniversityDBContext ctx)
        {
            _ctx = ctx;
        }
        public void AddUser(User user)
        {
            _ctx.Add(user);
        }

        public bool IsExistEmail(string email)
        {
            return _ctx.Users.Any(u => u.Email == email);
        }

        public bool IsExistUserName(string userName)
        {
            return _ctx.Users.Any(u => u.UserName == userName);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
