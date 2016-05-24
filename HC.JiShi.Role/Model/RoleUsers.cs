using System;
using System.Collections.Generic;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class RoleUsers
    {
        public Role Role { get; set; }

        public List<User> Users { get; set; }
    }
}