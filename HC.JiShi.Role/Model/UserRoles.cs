using System;
using System.Collections.Generic;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class UserRoles
    {
        public User User { get; set; }

        public List<Role> Roles { get; set; }
    }
}