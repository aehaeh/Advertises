using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Advertises.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
       
             
        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [BindProperty]
        public IList<Advertisement> Advertisements
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


        public void OnGet()
        {
            Advertisements = _context.Advertisements
                .Include(x => x.Local)
                .ThenInclude(x => x.City)
                .ToList();
        }
        public void OnPost()
        {

            Advertisements= _context.Advertisements.Where(x => x.Title.Contains(Mysearch)).ToList();
            
        }
    }
}
