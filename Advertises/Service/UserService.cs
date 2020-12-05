using Advertises.Models;
using Advertises.Service.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class UserService : IUserService
    {

        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Delete(User user)
        {
            _context.Users.Remove(user);
            var res =_context.SaveChanges();
            return res==0;
        }
        public async Task<User> Insert(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Get(long id)
        {
            return _context.Users.FirstOrDefault(s => s.Id == id);

        }
        public IQueryable<User> GetAll()
        {
            return _context.Users;

        }
        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
