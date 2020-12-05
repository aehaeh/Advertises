using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    interface IInnerCategoryService
    {
        Task<InnerCategory> Insert(InnerCategory ineercategory);
        Task<InnerCategory> Update(InnerCategory ineercategory);
        IQueryable<InnerCategory> GetAll();
        bool Delete(InnerCategory innerCategory);
        InnerCategory Get(long id);
    }
}
