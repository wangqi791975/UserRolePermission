using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PageImp
{
    public interface IPageDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="pagePo"></param>
        /// <returns></returns>
        int AddPge(PagePo pagePo);

        /// <summary>
        /// 通过Id删除
        /// </summary>
        /// <param name="id"></param>
        void DeletePage(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeletePages(List<int> ids);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="pagePo"></param>
        void UpdatePage(PagePo pagePo);

        /// <summary>
        /// 修改页面名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageName"></param>
        void UpdatePageName(int id, string pageName);

        /// <summary>
        /// 修改页面url
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        void UpdatePageUrl(int id, string url);

        /// <summary>
        /// 修改域名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="domain"></param>
        void UpdatePageDomain(int id, string domain);

        /// <summary>
        /// 通过Id获取页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PagePo GetPage(int id);

        /// <summary>
        /// 通过名称获取页面
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        PagePo GetPage(string pageName);

        /// <summary>
        /// 通过名称获取页面（不包含Id）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageName"></param>
        /// <returns></returns>
        PagePo GetPageWithoutId(int id, string pageName);

        /// <summary>
        /// 通过url获取页面
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        PagePo GetPageByUrl(string url);

        /// <summary>
        /// 通过url获取页面（不包含Id）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        PagePo GetPageByUrlWithoutId(int id, string url);

        /// <summary>
        /// 获取全部页面
        /// </summary>
        /// <returns></returns>
        IList<PagePo> GetPageList();

        /// <summary>
        /// 获取全部页面（包含Module信息）
        /// </summary>
        /// <returns></returns>
        IList<PageViewPo> GetPageViewList(string orderStr);
            
        /// <summary>
        /// 获取用户对应页面
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<PagePo> GetPageListByUserId(int userId);

        /// <summary>
        /// 获取角对应页面
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IList<PagePo> GetPageListByRoleId(int roleId);
    }
}