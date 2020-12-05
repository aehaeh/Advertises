using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public interface ICategoryService
    {
        Task<Category>  Insert(Category category);
        Task<Category> Update(Category category);
        IQueryable<Category> GetAll();
        bool Delete(Category category);
        Category Get(long id);

    }
}
