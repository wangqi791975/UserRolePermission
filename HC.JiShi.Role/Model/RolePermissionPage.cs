using System;
using System.Collections.Generic;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class RolePermissionPage
    {
        public int RoleId { get; set; }

        public List<Page> Pages { get; set; }
    }
}