using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class RoleService : IRoleService
    {


        private ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Delete(Role role)
        {
            _context.Roles.Remove(role);
            var res=_context.SaveChanges();
            return res==0;
        }
        public async Task<Role> Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
        public async Task<Role> Insert(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return role;
        }


        public Role Get(long id)
        {
            return _context.Roles.FirstOrDefault(s => s.Id == id);

        }
        public IQueryable<Role> GetAll()
        {
            return _context.Roles;
        }
    }
}

