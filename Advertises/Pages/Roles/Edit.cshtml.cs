using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
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

        [BindProperty]
        public Role MyRole
        { set; get; }
        public void OnGet(long id)
        {
            MyRole =_roleService.Get(id); 

        }
      
        public void Onpost()
        {
            var tt = _roleService.Get(MyRole.Id);
            tt.RoleName = MyRole.RoleName;

            _roleService.Update(tt);
            
        }
    }
}