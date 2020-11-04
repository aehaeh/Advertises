using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class DeleteLocalModel : PageModel
    {
        private ApplicationDbContext _context;

        public DeleteLocalModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Local MyLocal
        {
            set;
            get;
        }
        public void OnGet(int? id)
        {
            MyLocal = _context.Locations.SingleOrDefault(m => m.Id == id);
        }
        public void OnPost(int? id)
        {
            _context.Locations.SingleOrDefault(m => m.Id == id);
            if (MyLocal != null)
            {
                _context.Locations.Remove(MyLocal);
                _context.SaveChanges();
            }
        }
    }
}