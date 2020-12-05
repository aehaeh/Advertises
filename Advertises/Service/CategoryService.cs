using Advertises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Service
{
    public class CategoryService:ICategoryService  
    {

        private ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }
        public bool Delete(Category category)
        {
            _context.Categories.Remove(category);
           var res= _context.SaveChanges();
            return res ==0;
        }
        public Category Get(long id)
        {
            return _context.Categories.SingleOrDefault(s => s.Id == id);
        }
        public async Task<Category> Insert(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        public async Task<Category>Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}
