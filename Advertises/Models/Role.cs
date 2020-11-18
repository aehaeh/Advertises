using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Role
    {
        public string RoleName
        {
            get;
            set;
        }
        public long RoleId
        {
            get;
            set;
        }
        public List<UserRole> UserRoles { get; set; }
    }
}
