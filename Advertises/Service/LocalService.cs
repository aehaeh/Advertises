using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class LocalService : ILocalService
    {
        private ApplicationDbContext _context;

        public LocalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(Local local)
        {
            _context.Locations.Remove(local);
            var res = _context.SaveChanges();
            return res == 0;
        }

        public Local Get(long id)
        {
            return _context.Locations.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<Local> GetAll()
        {
            return _context.Locations;
        }

        public async Task<Local> Insert(Local local)
        {
            _context.Locations.Add(local);
            _context.SaveChanges();
            return local;
        }
        public async Task<Local> Update(Local local)
        {
            _context.Locations.Update(local);
            _context.SaveChanges();
            return local;
        }
    }
}
