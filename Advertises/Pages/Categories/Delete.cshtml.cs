using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class DeleteCategoryModel : PageModel
    {
        private IBaseService<Category> _categoryService;

        public DeleteCategoryModel(IBaseService<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        [BindProperty]

        public Category MyCategory
        {
            set;
            get;
        }
        public void OnGet(long id)
        {
            //MyCategory= _context.Categories.SingleOrDefault(m => m.Id == id);
            MyCategory = _categoryService.Get(id);

        }
        public void OnPost(long id)
        {
            //_context.Categories.SingleOrDefault(m => m.Id == id);
           _categoryService.Get(id);
            if (MyCategory != null)
            {
                _categoryService.Delete(MyCategory.Id);
                //_context.Categories.Remove(MyCategory);
                //_context.SaveChanges();
            }
        }
    }
}