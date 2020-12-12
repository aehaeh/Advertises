using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Models.ViewModels;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Roles
{
    public class EditModel : PageModel
    {
        private IBaseService<Role> _roleService;

        public EditModel(IBaseService<Role> roleService)
        {
            _roleService = roleService;
        }

        [BindProperty(SupportsGet = true)]
        public RoleViewModel MyRole
        { set; get; }
        public void OnGet(long id)
        {
            var localRole =_roleService.Get(id);
            MyRole.CreateDate = localRole.CreateDate;
            MyRole.Id = localRole.Id;
            MyRole.RoleName = localRole.RoleName;
            MyRole.UpdatedDate = localRole.UpdatedDate;
            MyRole.UserRoles = localRole.UserRoles;
           
        }
      
        public IActionResult Onpost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            

            var tt = _roleService.Get(MyRole.Id);
            tt.RoleName = MyRole.RoleName;

            _roleService.Update(tt);
            return Page();

        }
    }
}