using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام کاربری  ضروری  است ")]
        public string UserName { set; get; }



        public string FirstName { set; get; }
        public string LasttName { set; get; }
        public string PhoneNumber { set; get; }
        [Required(ErrorMessage = "وارد کردن کلمه عبور  ضروری  است ")]
        public string Password { set; get; }

        public List<UserRole> UserRoles { set; get; }
    }
}
