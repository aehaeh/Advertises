using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    interface ILocalService
    {
        Task<Local> Insert(Local local);

        Task<Local> Update(Local local);

        IQueryable<Local> GetAll();

        bool Delete(Local local);
        Local Get(long id);
    }
}
