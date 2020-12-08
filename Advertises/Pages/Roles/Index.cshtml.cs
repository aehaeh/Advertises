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
    public class IndexModel : PageModel
    {
       
        private IBaseService<Role> _roleService;

        public IndexModel(IBaseService<Role> roleService)
        {
            _roleService = roleService;
        }

        public List<Role> Roles
        { set; get; }

        public void OnGet()
        {
            Roles = _roleService.GetAll().ToList();
        }
    }
}