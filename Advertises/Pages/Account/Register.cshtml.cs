using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises
{
    public class RegisterModel : PageModel
    {
        private ApplicationDbContext _context;

        public RegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User MyUser
        {
            set;
            get;
        }

        public void OnGet()
        {

        }
        public void OnPost()
        {
            _context.Users.Add(MyUser);
            _context.SaveChanges();

            
        }

    }
}