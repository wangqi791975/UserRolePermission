using System;
using System.Collections.Generic;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class UserPermissionPage
    {
        public int UserId { get; set; }

        public List<Page> Pages { get; set; }
    }
}