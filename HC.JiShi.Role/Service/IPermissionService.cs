using System.Collections.Generic;
using HC.JiShi.UserRole.Model;

namespace HC.JiShi.UserRole.Service
{
    public interface IPermissionService
    {
        #region UserPermission
        /// <summary>
        /// 绑定用户权限页面
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageId"></param>
        int BindUserPermissionPage(int userId, int pageId);

        /// <summary>
        /// 批量绑定用户权限页面
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageIds"></param>
        void BindUserPermissionPage(int userId, List<int> pageIds);

        /// <summary>
        /// 绑定用户权限页面行为
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageActionId"></param>
        /// <returns></returns>
        int BindUserPermissionPageAction(int userId, int pageActionId);

        /// <summary>
        /// 批量绑定用户权限页面行为
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="pageActionIds"></param>
        void BindUserPermissionPageAction(int userId, List<int> pageActionIds);

        /// <summary>
        /// 获取用户有权限的页面
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserPermissionPage GetUserPermissionPage(int userId);

        /// <summary>
        /// 通过用户Id获取用户有权的页面的url  key：userId  value：页面url
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<string> GetUserPermissionPageUrl(int userId);

        /// <summary>
        /// 获取所有用户有权限的页面
        /// </summary>
        /// <returns></returns>
        IList<UserPermissionPage> GetUserPermissionPage();

        /// <summary>
        /// 获取用户有权限的页面行为
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserPermissionPageAction GetUserPermissionPageAction(int userId);

        /// <summary>
        /// 获取所有用户有权限的页面行为
        /// </summary>
        /// <returns></returns>
        IList<UserPermissionPageAction> GetUserPermissionPageAction();
        #endregion

        #region RolePermission
        /// <summary>
        /// 绑定角色权限页面
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        int BindRolePermissionPage(int roleId, int pageId);

        /// <summary>
        /// 批量绑定角色权限页面
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="pageIds"></param>
        void BindRolePermissionPage(int roleId, List<int> pageIds);

        /// <summary>
        /// 批量绑定角色权限页面
        /// </summary>
        /// <param name="roleId"></param>
        void UnBindRolePermissionPage(int roleId);

        /// <summary>
        /// 绑定角色权限页面行为
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="pageActionId"></param>
        /// <returns></returns>
        int BindRolePermissionPageAction(int roleId, int pageActionId);

        /// <summary>
        /// 批量绑定角色权限页面行为
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="pageActionIds"></param>
        void BindRolePermissionPageAction(int roleId, List<int> pageActionIds);

        /// <summary>
        /// 获取角色有权限的页面
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RolePermissionPage GetRolePermissionPage(int roleId);

        /// <summary>
        /// 获取所有角色有权限的页面
        /// </summary>
        /// <returns></returns>
        List<RolePermissionPage> GetRolePermissionPage();

        /// <summary>
        /// 获取角色有权限的页面行为
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        RolePermissionPageAction GetRolePermissionPageAction(int roleId);

        /// <summary>
        /// 获取所有角色有权限的页面行为
        /// </summary>
        /// <returns></returns>
        List<RolePermissionPageAction> GetRolePermissionPageAction();
        #endregion
    }
}