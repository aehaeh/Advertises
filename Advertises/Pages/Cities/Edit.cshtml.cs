using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Cities
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public City MyCity
        {
            set;
            get;
        }


        public void OnGet(long id)
        {
            MyCity = _context.Cities.FirstOrDefault(x => x.Id == id);
        }
        public void Onpost()
        {
            var tt = _context.Cities.FirstOrDefault(x => x.Id == MyCity.Id);
            tt.Name = MyCity.Name;

            _context.Cities.Update(tt);
            _context.SaveChanges();
        }
    }
}