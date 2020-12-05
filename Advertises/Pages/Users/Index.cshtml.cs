using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Advertises.Pages.Users
{
    public class IndexModel : PageModel
    {
        private IBaseService<User> _userService;
        
        public IndexModel(IBaseService<User> userService)
        {
            _userService = userService;
        }

        public List<User> Users
        {
            set;get;
        }
        public void OnGet()
        {
            Users = _userService.GetAll().ToList();
        }
    }
}