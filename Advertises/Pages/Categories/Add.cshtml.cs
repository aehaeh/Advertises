using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class AddCategoryModel : PageModel
    {
        private ApplicationDbContext _context;

        public AddCategoryModel(ApplicationDbContext context)
        {
            _context = context;
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
            MyCategory.CreateDate = DateTime.Now;
            _context.Categories.Add(MyCategory);
            _context.SaveChanges();
        }
    }
}