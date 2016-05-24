using System;
using System.Collections.Generic;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class RolePermissionPageAction
    {
        public int RoleId { get; set; }

        public List<PageAction> PageActions { get; set; }
    }
}