using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class User :BaseEntity
    {
        [Display(Name ="نام کاربری")]
        public string UserName { set; get; }
       
        

        public string FirstName { set; get; }
        public string LasttName { set; get; }
        public string PhoneNumber { set; get; }
        public string Password { set; get; }
     
        public List<UserRole> UserRoles { set; get; }


       

       


    }
    
}
