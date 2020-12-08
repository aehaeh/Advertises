﻿using System;
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
        public CategoryViewModel MyCategory
        { set; get; }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            //MyCategory.CreateDate = DateTime.Now;
            //_context.Categories.Add(MyCategory);
            //_context.SaveChanges();



            Category persistCtegory = new Category();
            persistCtegory.Title = MyCategory.Title;
            persistCtegory.advertisements = MyCategory.advertisements;
            persistCtegory.Id = MyCategory.Id;
            _categoryService.Insert(persistCtegory);
        }
    }
}