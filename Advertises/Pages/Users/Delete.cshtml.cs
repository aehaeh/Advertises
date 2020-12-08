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
    public class DeleteModel : PageModel
    {
        private IBaseService<User>_userService;

        public DeleteModel(IBaseService<User> userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User MyUser
        { set; get; }
        public void OnGet(long id)
        {
            MyUser = _userService.Get(id);
        }
        public void OnPost()
        {

            if (MyUser != null)
            {
                _userService.Delete(MyUser.Id);
                
            }
        }
    }
}