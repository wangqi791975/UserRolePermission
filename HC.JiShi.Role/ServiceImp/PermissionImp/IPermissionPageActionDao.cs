using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PermissionImp
{
    public interface IPermissionPageActionDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionPageActionPo"></param>
        /// <returns></returns>
        int AddPermissionPageAction(PermissionPageActionPo permissionPageActionPo);

        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="permissionPageActionPos"></param>
        void AddPermissionPageAction(List<PermissionPageActionPo> permissionPageActionPos);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void DeletePermissionPageAction(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeletePermissionPageActions(List<int> ids);

        /// <summary>
        /// 修改权限页面行为
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageActionId"></param>
        void UpdatePermissionPageActionPageActionId(int id, int pageActionId);
    }
}