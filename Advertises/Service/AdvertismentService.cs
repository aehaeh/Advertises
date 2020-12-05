using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class AdvertismentService : IAdvertismentService
    {
        private ApplicationDbContext _context;

        public AdvertismentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(Advertisement advertisement)
        {
            _context.Advertisements.Remove(advertisement);
            var res = _context.SaveChanges();
            return res == 0;
        }

        public Advertisement Get(long id)
        {
            return _context.Advertisements.SingleOrDefault(s => s.Id == id);

        }

        public IQueryable<Advertisement> GetAll()
        {
            return _context.Advertisements;
        }

        public async Task<Advertisement> Insert(Advertisement advertisement)
        {
            _context.Advertisements.Add(advertisement);
            _context.SaveChanges();
            return advertisement;
        }

        public async Task<Advertisement> Update(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
            _context.SaveChanges();
            return advertisement;
        }
    }
}
