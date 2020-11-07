using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.InnerCategories
{
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InnerCategory MyInnerCategory
        {
            set;
            get;
        }
        public void OnGet(int? id)
        {
            MyInnerCategory = _context.InnerCategories.SingleOrDefault(m => m.Id == id);
        }
        public void OnPost(int? id)
        {
            _context.InnerCategories.SingleOrDefault(m => m.Id == id);
            if (MyInnerCategory != null)
            {
                _context.InnerCategories.Remove(MyInnerCategory);
                _context.SaveChanges();
            }
        }
    }
}