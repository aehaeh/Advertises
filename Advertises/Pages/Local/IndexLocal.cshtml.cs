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
    public class IndexLocalModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexLocalModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<Local> Locations
        {
            get;
            set;
        }
        public DbSet<Advertisement> Advertisementlist { get; private set; }
        public void OnGet()
        {
           Locations = _context.Locations.ToList();
        }
    }
}