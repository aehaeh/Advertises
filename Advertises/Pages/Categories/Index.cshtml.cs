using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class IndexModel : PageModel
       
    {
       private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Category> Categories 
        {
            get;
            set; 
        }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();
                
        }

       
        public void OnPost()
        {
            
        }
    }
}