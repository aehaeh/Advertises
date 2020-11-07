using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.InnerCategories
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public IList<InnerCategory> InnerCategories
        {
            get;
            set;
        }
        public DbSet<Advertisement> Advertisementlist { get; private set; }
        public void OnGet()
        {
            InnerCategories = _context.InnerCategories.ToList();
        }
    }
}