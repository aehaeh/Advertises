using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Advertisements

{
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _context;
     

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Advertisement Myadvrtisment
        {
            get;
            set;
        }
     

        public void OnGet(long id)
        {
           Myadvrtisment= _context.Advertisements.SingleOrDefault(m => m.Id == id);
           
        }
        public void OnPost()
        {
            if (Myadvrtisment != null)
            {
                _context.Advertisements.Remove(Myadvrtisment);
                _context.SaveChanges();
            }
        }
    }
}

