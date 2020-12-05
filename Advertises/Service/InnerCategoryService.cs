using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class InnerCategoryService : IInnerCategoryService
    {
        private ApplicationDbContext _context;
        public InnerCategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<InnerCategory> Insert(InnerCategory innerCategory)
        {
            _context.InnerCategories.Add(innerCategory);
            _context.SaveChanges();
            return innerCategory;
        }
        public async Task<InnerCategory> Update(InnerCategory innerCategory)
        {
            _context.InnerCategories.Update(innerCategory);
            _context.SaveChanges();
            return innerCategory;
        }
        public bool Delete(InnerCategory innerCategory)
        {
            _context.InnerCategories.Remove(innerCategory);
           var res= _context.SaveChanges();
            return res==0;
        }
        public InnerCategory Get(long id)
        {
            return _context.InnerCategories.SingleOrDefault(s => s.Id == id);
        }
        public IQueryable<InnerCategory> GetAll()
        {
            return _context.InnerCategories;
        }


    }
}
