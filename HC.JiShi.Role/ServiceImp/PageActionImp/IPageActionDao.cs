using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PageActionImp
{
    public interface IPageActionDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pageActionPo"></param>
        /// <returns></returns>
        int AddPageAction(PageActionPo pageActionPo);

        /// <summary>
        /// 通过Id删除
        /// </summary>
        /// <param name="id"></param>
        void DeletePageAction(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeletePageActions(List<int> ids);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pageActionPo"></param>
        void UpdatePageAction(PageActionPo pageActionPo);

        /// <summary>
        /// 修改页面行为对应页面
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageId"></param>
        void UpdatePageActionPageId(int id, int pageId);

        /// <summary>
        /// 修改页面行为名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageActionName"></param>
        void UpdatePageActionName(int id, string pageActionName);

        /// <summary>
        /// 修改页面行为url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="actionUrl"></param>
        void UpdatePageActionUrl(int id, string actionUrl);

        /// <summary>
        /// 通过Id获取页面行为
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PageActionPo GetPageAction(int id);

        /// <summary>
        /// 通过页面Id和页面行为名称获取页面行为
        /// </summary>
        /// <param name="pageId"></param>
        /// <param name="pageActionName"></param>
        /// <returns></returns>
        PageActionPo GetPageAction(int pageId, string pageActionName);

        /// <summary>
        /// 通过页面Id获取页面行为
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        IList<PageActionPo> GetPageActionListByPageId(int pageId);

        /// <summary>
        /// 获取全部页面
        /// </summary>
        /// <returns></returns>
        IList<PageActionPo> GetPageActionList();

        /// <summary>
        /// 获取用户对应页面行为
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<PageActionPo> GetPageActionListByUserId(int userId);

        /// <summary>
        /// 获取角色对应对面行为
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IList<PageActionPo> GetPageActionListByRoleId(int roleId);
    }
}