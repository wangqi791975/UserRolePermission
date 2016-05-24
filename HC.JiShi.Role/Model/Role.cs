using System;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class Role
    {
        public int Id { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        public string RoleName { get; set; }

        /// <summary>
        /// 是否是超级管理员，超级管理员不判断权限，拥有所有页面及其操作的权限
        /// </summary>
        public bool IsAdmin { get; set; }

        public bool IsValid { get; set; } 

        public DateTime CreateDate { get; set; }
    }
}