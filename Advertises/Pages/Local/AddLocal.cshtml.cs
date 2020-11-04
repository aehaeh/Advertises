using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class AddLocalModel : PageModel
    {
        private ApplicationDbContext _context;

        public AddLocalModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Local MyLocal
        {
            set;
            get;
        }

        public void OnGet()
        {

        }
        public void Onpost()
        {
            MyLocal.CreateDate = DateTime.Now;
            _context.Locations.Add(MyLocal);
            _context.SaveChanges();
        }
    }
}