using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PermissionImp
{
    public interface IPermissionPageDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionPagePo"></param>
        /// <returns></returns>
        int AddPermissionPage(PermissionPagePo permissionPagePo);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="permissionPagePos"></param>
        void AddPermissionPage(List<PermissionPagePo> permissionPagePos);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void DeletePermissionPage(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeletePermissionPages(List<int> ids);

        /// <summary>
        /// 通过角色Id删除页面权限
        /// </summary>
        /// <param name="roleId"></param>
        void DeletePermissionPageByRoleId(int roleId);

        /// <summary>
        /// 修改权限页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageId"></param>
        void UpdatePermissionPagePageId(int id, int pageId);
    }
}