using System;

namespace HC.JiShi.UserRole.Entity
{
    [Serializable]
    public class UserRolePo
    {
        public int Id { get; set; }

        public int RoleId { get; set; }

        public int UserId { get; set; }
    }
}