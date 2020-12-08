using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
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
        public RoleViewModel MyRole
        { set; get; }


        public void OnGet()
        {
           
        }
        public void OnPost()
        {
            Role persistRole = new Role();
            persistRole.CreateDate = MyRole.CreateDate;
            persistRole.Id = MyRole.Id;
            persistRole.RoleName = MyRole.RoleName;
            persistRole.UpdatedDate = MyRole.UpdatedDate;
            persistRole.UserRoles = MyRole.UserRoles;
            _roleService.Insert(persistRole);
            
        }
    }
}