using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises.Pages.Roles
{
    public class AddModel : PageModel
    {
        public List<SelectListItem> ListRoles { get; set; } = new List<SelectListItem>();
        private ApplicationDbContext _context;

        public AddModel(ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Role MyRole
        {
            set;
            get;
        }
       

        public void OnGet()
        {
           
        }
        public void OnPost()
        {
            _context.Roles.Add(MyRole);
            _context.SaveChanges();
        }
    }
}