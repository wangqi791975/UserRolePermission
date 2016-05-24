using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.RoleImp
{
    public interface IRoleDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="rolePo"></param>
        /// <returns></returns>
        int AddRole(RolePo rolePo);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteRole(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeleteRoles(List<int> ids);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="rolePo"></param>
        void UpdateRole(RolePo rolePo);

        /// <summary>
        /// 更新角色名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleName"></param>
        void UpdateRole(int id, string roleName);

        /// <summary>
        /// 修改角色超级管理员值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isAdmin"></param>
        void UpdateRoleIsAdmin(int id, bool isAdmin);

        /// <summary>
        /// 批量修改角色超级管理员值
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="isAdmin"></param>
        void UpdateRoleIsAdmin(List<int> ids, bool isAdmin);

        /// <summary>
        /// 修改角色是否有效值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isValid"></param>
        void UpdateRoleIsValid(int id, bool isValid);

        /// <summary>
        /// 批量修改角色是否有效值
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="isValid"></param>
        void UpdateRoleIsValid(List<int> ids, bool isValid);

        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RolePo GetRole(int id);

        /// <summary>
        /// 通过角色名称获取角色名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        RolePo GetRole(string name);

        /// <summary>
        /// 通过角色名称获取角色名（不包含Id）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        RolePo GetRoleWithoutId(int id, string name);

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <returns></returns>
        IList<RolePo> GetRoleList(string strOrder);

        /// <summary>
        /// 获取用户对应所有角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<RolePo> GetRoleList(int userId);

        /// <summary>
        /// 获取角色可访问的页面
        /// </summary>
        /// <returns></returns>
        IList<RolePermissionPagePo> GetRolePermissionPageList();

        /// <summary>
        /// 获取角色可操作的所有页面行为
        /// </summary>
        /// <returns></returns>
        IList<RolePermissionPageActionPo> GetRolePermissionPageActionList();
    }
}