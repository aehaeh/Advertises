using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises
{
    public class addAdvertisementModel : PageModel
    {
        private ApplicationDbContext _context;
        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();

        public addAdvertisementModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Advertisement MyAdvertisement
        {
            set;
            get;
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

        public void OnGet()
        {
            var categories = _context.Categories.ToList();
            PopulateCategoryDropDownList(categories, null);
        }
        public void OnPost()
        {
            MyAdvertisement.CreateDate = DateTime.Now;
            MyAdvertisement.IsActive = false;
            _context.Advertisements.Add(MyAdvertisement);
            _context.SaveChanges();

        }
    }
}