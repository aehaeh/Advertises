using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class UserRole
    {
        public User User
        {
            get;set;
        }
        public long UserId
        {
            get;
            set;
        }
        public Role Role
        {
            get;set;
        }
        public long RoleId
        {
            set;
            get;
        }
    }
}
