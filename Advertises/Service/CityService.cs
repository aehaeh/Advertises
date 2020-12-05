using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class CityService : ICityService
    {
        private ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Delete(City city)
        {
            _context.Cities.Remove(city);
           var res = _context.SaveChanges();
            return res==0;
        }

        public City Get(long id)
        {
            return _context.Cities.SingleOrDefault(s => s.Id == id);
        }

        public IQueryable<City> GetAll()
        {
            return _context.Cities;
        }

        public async Task<City> Insert(City city)
        {
            _context.Cities.Add(city);
            _context.SaveChanges();
            return city;
        }

        public async Task<City> Update(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
            return city;
        }
    }
}

