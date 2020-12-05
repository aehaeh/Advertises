using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    interface ICityService
    {
        Task<City> Insert(City city);
        Task<City> Update(City city);

        IQueryable<City> GetAll();

        bool Delete(City city);
        City Get(long id);
    }
}
