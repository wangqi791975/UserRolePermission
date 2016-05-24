using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.UserRoleImp
{
    public interface IUserRoleDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userRole"></param>
        /// <returns></returns>
        int AddUserRole(UserRolePo userRole);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="userRoles"></param>
        void AddUserRole(List<UserRolePo> userRoles);

        /// <summary>
        /// 删除用户角色关系
        /// </summary>
        /// <param name="id"></param>
        void DeleteUserRole(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeleteUserRole(List<int> ids);

        /// <summary>
        /// 通过用户Id删除用户角色关系
        /// </summary>
        /// <param name="userId"></param>
        void DeleteUserRoleByUserId(int userId);

        /// <summary>
        /// 通过角色Id删除用户角色关系
        /// </summary>
        /// <param name="roleId"></param>
        void DeleteUserRoleByRoleId(int roleId);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="userRole"></param>
        void UpdateUserRole(UserRolePo userRole);
    }
}