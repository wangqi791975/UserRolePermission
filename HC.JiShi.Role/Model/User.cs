using System;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 角色是否是管理员
        /// </summary>
        public bool RoleIsAdmin { get; set; }

        /// <summary>
        /// 是否拥有管理员权限
        /// </summary>
        public bool HasAdmin { get { return IsAdmin || RoleIsAdmin; } }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
    }
}