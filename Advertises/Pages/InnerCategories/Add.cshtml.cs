using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises.Pages.InnerCategories
{
    public class AddModel : PageModel
    {
        public List<SelectListItem> ListCategories { get; set; } = new List<SelectListItem>();
        private ApplicationDbContext _context;

        public AddModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InnerCategory MyInnerCategory
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
        public void Onpost()
        {
            
            _context.InnerCategories.Add(MyInnerCategory);
            _context.SaveChanges();
        }
    }
}