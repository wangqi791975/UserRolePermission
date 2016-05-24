using System.Collections.Generic;
using HC.JiShi.UserRole.Model;

namespace HC.JiShi.UserRole.Service
{
    public interface IPageActionService
    {
        /// <summary>
        /// 添加页面行为
        /// </summary>
        /// <param name="pageAction"></param>
        /// <returns></returns>
        int AddPageAction(PageAction pageAction);

        /// <summary>
        /// 删除页面行为
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeletePageAction(int id);

        /// <summary>
        /// 批量删除页面行为
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void DeletePageAction(List<int> ids);

        /// <summary>
        /// 修改页面行为
        /// </summary>
        /// <param name="pageAction"></param>
        /// <returns></returns>
        void UpdatePageAction(PageAction pageAction);

        /// <summary>
        /// 修改页面行为对应页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageId"></param>
        /// <returns></returns>
        void UpdatePageAction(int id, int pageId);

        /// <summary>
        /// 修改行为名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageActionName"></param>
        /// <returns></returns>
        void UpdatePageActionName(int id, string pageActionName);

        /// <summary>
        /// 修改行为url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageActionUrl"></param>
        /// <returns></returns>
        void UpdatePageActionUrl(int id, string pageActionUrl);

        /// <summary>
        /// 获取页面行为
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PageAction GetPageAction(int id);

        /// <summary>
        /// 获取所有页面行为
        /// </summary>
        /// <returns></returns>
        List<PageAction> GetPageActionList();

        /// <summary>
        /// 获取用户可操作的行为
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<PageAction> GetPageActionListByUserId(int userId);

        /// <summary>
        /// 获取角色可操作的行为
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<PageAction> GetPageActionListByRoleId(int roleId);
    }
}