using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Roles
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Role MyRole
        {
            get;
            set;
        }
        public void OnGet(long id)
        {
            MyRole = _context.Roles.FirstOrDefault(x => x.RoleId == id); 

        }
      
        public void Onpost()
        {
            var tt = _context.Roles.FirstOrDefault(x => x.RoleId == MyRole.RoleId);
            tt.RoleName = MyRole.RoleName;

            _context.Roles.Update(tt);
            _context.SaveChanges();
        }
    }
}