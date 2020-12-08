using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advertises.Models
{
    public class UserRole
    {
        public User User
        { set; get; }
        public long UserId
        { set; get; }
        public Role Role
        { set; get; }
        public long RoleId
        { set; get; }
    }
}
