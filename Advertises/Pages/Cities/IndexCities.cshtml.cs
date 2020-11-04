using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises
{
    public class IndexCitiesModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexCitiesModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<City> Cities
        {
            get;
            set;
        }
        public DbSet<Advertisement> Advertisementlist { get; private set; }

        public void OnGet()
        {
            Cities = _context.Cities.ToList();
        }
    }
}