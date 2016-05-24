using System;
using System.Collections.Generic;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class UserPermissionPageAction
    {
        public int UserId { get; set; }

        public List<PageAction> PageActions { get; set; }
    }
}