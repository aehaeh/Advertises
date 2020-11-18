using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.InnerCategories
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InnerCategory MyInnerCategory
        {
            set;
            get;
        }

        public void OnGet(long id)
        {
            MyInnerCategory = _context.InnerCategories.FirstOrDefault(x => x.Id == id);
        }
        public void Onpost()
        {
            var tt = _context.InnerCategories.FirstOrDefault(x => x.Id == MyInnerCategory.Id);
            tt.Title = MyInnerCategory.Title;

            _context.InnerCategories.Update(tt);
            _context.SaveChanges();
        }
    }
}