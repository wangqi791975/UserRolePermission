using System.Collections.Generic;
using HC.JiShi.UserRole.Model;

namespace HC.JiShi.UserRole.Service
{
    public interface IRoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int AddRole(Role role);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteRole(int id);

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void DeleteRoles(List<int> ids);

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        void UpdateRole(Role role);

        /// <summary>
        /// 修改角色名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        void UpdateRole(int id, string roleName);

        /// <summary>
        /// 设置角色的超级管理员权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void UpdateRoleIsAdmin(int id);

        /// <summary>
        /// 批量设置角色的超级管理员权限
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void UpdateRoleIsAdmin(List<int> ids);

        /// <summary>
        /// 取消角色的超级管理员权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void UpdateRoleIsNotAdmin(int id);

        /// <summary>
        /// 批量取消角色的超级管理员权限
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void UpdateRoleIsNotAdmin(List<int> ids);

        /// <summary>
        /// 设置角色有效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void UpdateRoleIsValid(int id);

        /// <summary>
        /// 批量设置角色有效
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void UpdateRoleIsValid(List<int> ids);

        /// <summary>
        /// 设置角色失效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void UpdateRoleIsNotValid(int id);

        /// <summary>
        /// 批量设置角色失效
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void UpdateRoleIsNotValid(List<int> ids);

        /// <summary>
        /// 通过角色Id获取角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Role GetRole(int id);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoleList(string strOrder);

        /// <summary>
        /// 获取角色对应的所有用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RoleUsers GetRoleUsers(int roleId);

        /// <summary>
        /// 获取不在角色的所有用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RoleUsers GetNotInRoleUsers(int roleId);

        /// <summary>
        /// 绑定角色用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        void BindRoleUser(int roleId, int userId);

        /// <summary>
        /// 角色绑定多个用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="userIds"></param>
        void BindRoleUser(int roleId, List<int> userIds);

        /// <summary>
        /// 解除绑定
        /// </summary>
        /// <param name="roleId"></param>
        void UnBindRoleUser(int roleId);
    }
}