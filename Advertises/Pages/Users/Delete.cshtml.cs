using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Users
{
    public class DeleteModel : PageModel
    {

        private ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public User MyUser
        {
            get;
            set;

        }
        public void OnGet(int? id)
        {
            MyUser = _context.Users.SingleOrDefault(m => m.UserId == id);
        }
        public void OnPost()
        {

            if (MyUser != null)
            {
                _context.Users.Remove(MyUser);
                _context.SaveChanges();
            }
        }
    }
}