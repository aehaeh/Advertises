using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    interface IRoleService
    {
        Task<Role> Insert(Role role);

        Task<Role> Update(Role role);

        IQueryable<Role> GetAll();

        bool Delete(Role role);
        Role Get(long id);
    }
}
