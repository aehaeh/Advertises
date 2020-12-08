using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models.ViewModels
{
    public class RoleViewModel
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "وارد کردن عنوان نقش  ضروری  است ")]
        public string RoleName
        { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
