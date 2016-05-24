using System;

namespace HC.JiShi.UserRole.Entity
{
    [Serializable]
    public class PermissionPageActionPo
    {
        public int Id { get; set; }

        /// <summary>
        /// 权限类型 1：表示UserRoleId是RoleId  2：表示UserRoleId是UserId
        /// </summary>
        public int Type { get; set; }

        public int UserRoleId { get; set; }

        public int PageActionId { get; set; }
    }
}