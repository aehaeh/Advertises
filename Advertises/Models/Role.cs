using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class Role : BaseEntity
    {
        public string RoleName
        { set; get; }

        public List<UserRole> UserRoles { get; set; }
    }
}
