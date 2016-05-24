using System.Collections.Generic;
using HC.JiShi.UserRole.Model;

namespace HC.JiShi.UserRole.Service
{
    public interface IPageService
    {
        /// <summary>
        /// 添加页面
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        int AddPage(Page page);

        /// <summary>
        /// 删除页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeletePage(int id);

        /// <summary>
        /// 批量删除页面
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void DeletePageList(List<int> ids);

        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        void UpdatePage(Page page);

        /// <summary>
        /// 修改页面名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        void UpdatePageName(int id, string pageName);

        /// <summary>
        /// 修改页面url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        void UpdatePageUrl(int id, string url);

        /// <summary>
        /// 修改页面域名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="domain"></param>
        /// <returns></returns>
        void UpdatePageDomain(int id, string domain);

        /// <summary>
        /// 获取页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Page GetPage(int id);

        /// <summary>
        /// 获取所有页面
        /// </summary>
        /// <returns></returns>
        IList<Page> GetPageList();

        /// <summary>
        /// 获取所有页面url
        /// </summary>
        /// <returns></returns>
        IList<string> GetPageUrlList();

        /// <summary>
        /// 获取所有页面
        /// </summary>
        /// <returns></returns>
        IList<PageView> GetPageViewList(string orderStr);

        /// <summary>
        /// 获取模块页面
        /// </summary>
        /// <returns></returns>
        IList<ModulePage> GetModulePages();
        
            /// <summary>
        /// 获取用户可访问的页面
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<Page> GetPageListByUserId(int userId);

        /// <summary>
        /// 获取角色可访问的页面
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IList<Page> GetPageListByRoleId(int roleId);
    }
}