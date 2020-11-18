using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Roles
{
    public class DeleteModel : PageModel
    {

        private ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Role MyRole
        {
            get;
            set;
        }

        public void OnGet(int? id)
        {
            MyRole = _context.Roles.SingleOrDefault(m => m.RoleId == id );
        }
        public void OnPost()
        {

            if (MyRole != null)
            {
                _context.Roles.Remove(MyRole);
                _context.SaveChanges();
            }
        }
    }
}