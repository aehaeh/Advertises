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
    public class AddCategoryModel : PageModel
    {
        private IBaseService<Category> _categoryService;


        public AddCategoryModel(IBaseService<Category> categoryService)
        {
            _categoryService = categoryService;
            
        }


        [BindProperty]
        public Category MyCategory
        {
            set;
            get;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            //MyCategory.CreateDate = DateTime.Now;
            //_context.Categories.Add(MyCategory);
            //_context.SaveChanges();
            MyCategory.CreateDate = DateTime.Now;
            _categoryService.Insert(MyCategory);
            
        }
    }
}