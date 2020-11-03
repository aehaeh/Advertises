using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.Categories
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
        [BindProperty]
        public string Mysearch
        {
            set;
            get;

        }
        public DbSet<Advertisement> Advertisementlist { get; private set; }

        public void OnGet()
        {
            Categories = _context.Categories.ToList();

        }

       
        public void OnPost()
        {
            
            var Advertisementlist = _context.Advertisements.Where(x => x.Title.IndexOf(Mysearch) != -1).ToList();
        }
    }
}