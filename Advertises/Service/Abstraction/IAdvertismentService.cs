using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public interface IAdvertismentService
    {
        Task<Advertisement> Insert(Advertisement advertisement);
        Task<Advertisement> Update(Advertisement advertisement);
        IQueryable<Advertisement> GetAll();

        bool Delete(Advertisement advertisement);
        Advertisement Get(long id);
    }
}
