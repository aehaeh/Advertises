﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();

        [BindProperty]
        public Advertisement MyAdvertisement
        {
            get;
            set;
        }


        public void OnGet(long id)
        {

            var categories = _context.Categories.ToList();
            PopulateCategoryDropDownList(categories, null);
           MyAdvertisement= _context.Advertisements.FirstOrDefault(x=>x.Id==id);
            
            
        }
        public void OnPost()
        {
            var ttt = _context.Advertisements.FirstOrDefault(x=>x.Id==MyAdvertisement.Id);
            ttt.Title = MyAdvertisement.Title;
            ttt.Description = MyAdvertisement.Description;
            ttt.IsActive = MyAdvertisement.IsActive;
            ttt.CategoryId = MyAdvertisement.CategoryId;


            _context.Advertisements.Update(ttt);
            _context.SaveChanges();

            var categories = _context.Categories.ToList();
            PopulateCategoryDropDownList(categories, null);
        }
        public void PopulateCategoryDropDownList(IList<Category> categories,
           List<long> selectedCategory)
        {
            var categoryQuery = from d in categories
                                orderby d.Title // Sort by name.
                                select d;

            ListCategories = categoryQuery.Select(v => new SelectListItem
            {
                Text = v.Title,
                Value = v.Id.ToString()
            }).ToList();
        }
    }
}