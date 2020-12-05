using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service.Abstraction
{
    interface IUserService
    {
        Task<User> Insert(User user);

        Task<User> Update(User user);

        IQueryable<User> GetAll();

        bool Delete(User user);
        User Get(long id);
    }
}
