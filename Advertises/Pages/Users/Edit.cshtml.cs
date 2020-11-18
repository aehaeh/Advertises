using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Users
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public User MyUser
        {
            get;
            set;
        }

        public void OnGet(long id)
        {
            MyUser = _context.Users.FirstOrDefault(x => x.UserId == id);
        }
        public void Onpost()
        {
            var tt = _context.Users.FirstOrDefault(x => x.UserId == MyUser.UserId);
            tt.UserName = MyUser.UserName;

            _context.Users.Update(tt);
            _context.SaveChanges();
        }
    }
}