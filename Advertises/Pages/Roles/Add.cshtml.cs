using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Advertises.Pages.Roles
{
    public class AddModel : PageModel
    {
        public List<SelectListItem> ListRoles { get; set; } = new List<SelectListItem>();
        private IBaseService<Role> _roleService;

        public AddModel(IBaseService<Role> roleService)
        {
            _roleService = roleService;
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
            _roleService.Insert(MyRole);
            
        }
    }
}