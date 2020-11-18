using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Users
{
    public class IndexModel : PageModel
    {

        private ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<User> Users
        {
            set;get;
        }
        public void OnGet()
        {
            Users = _context.Users.ToList();
        }
    }
}