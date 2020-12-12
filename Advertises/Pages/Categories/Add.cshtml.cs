using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
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
        public CategoryViewModel MyCategory{ set; get; }

        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            //MyCategory.CreateDate = DateTime.Now;
            //_context.Categories.Add(MyCategory);
            //_context.SaveChanges();

            if(!ModelState.IsValid)
            {
                return Page();
            }



            MyCategory.CreateDate = DateTime.Now;
            
            Category persistCtegory = new Category();
            persistCtegory.Title = MyCategory.Title;
            persistCtegory.advertisements = MyCategory.advertisements;
            persistCtegory.Id = MyCategory.Id;
            persistCtegory.UpdatedDate = MyCategory.UpdatedDate;
            persistCtegory.CreateDate = MyCategory.CreateDate;
            _categoryService.Insert(persistCtegory);

            return Page();
        }
    }
}