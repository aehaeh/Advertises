using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advertises.Models;
using Advertises.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Advertises.Pages.Users
{
    public class EditModel : PageModel
    {

        private IBaseService<User> _userService;
        private IBaseService<Role> _roleService;

        public EditModel(IBaseService<User> userService, IBaseService<Role> roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [BindProperty]
        public User MyUser
        { set; get; }

        public Role MyRole
        { set; get; }

        [BindProperty]
        public List<RoleVm> MyRoleVm { set; get; }

        //private void PopulateCheckBoxList(List<Role> roles)
        //{
        //    foreach (Role m in roles)
        //    {
        //        ListItem item = new ListItem(m.RoleName, m.RoleId.ToString());
        //        item.Selected = m.IsActive;
        //        checkbox.Items.Add(item);
        //    }
        //}
        public void OnGet(long id)
        {
            MyUser = _userService.GetAll()
                .Include(x=>x.UserRoles)
                .FirstOrDefault(x => x.Id == id);

            MyRoleVm = _roleService.GetAll().Select(v => new RoleVm()
            {
                Name = v.RoleName,
                Id = v.Id,
                Selected = MyUser.UserRoles.Select(x=>x.RoleId).Contains(v.Id)                
            }).ToList();
            
        }
        public void Onpost()
        {
            var ttt = _userService.GetAll()
                .Include(x => x.UserRoles)
                .FirstOrDefault(x => x.Id == MyUser.Id);

            ttt.UserRoles.Clear();

            var selectedRoles = MyRoleVm.Where(x => x.Selected).ToList();

            foreach (RoleVm selectedRole in selectedRoles)
            {
                ttt.UserRoles.Add(
                    new UserRole()
                    {
                        UserId = MyUser.Id,
                        RoleId = selectedRole.Id
                    }
                );
            }

            _userService.Update(ttt);
            
            //var tt = _context.Users.FirstOrDefault(x => x.UserId == MyUser.UserId);
            //tt.UserName = MyUser.UserName;



           // _context.Users.Update(ttt);
           // _context.SaveChanges();
        }



    }

    public class RoleVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }

}