using System.Collections.Generic;
using System.Linq;
using Autofac;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using HC.JiShi.UserRole.ServiceImp.PageImp;
using HC.Jishi.UserRole.Common;

namespace HC.JiShi.UserRole.ServiceImp
{
    public class PageService : IPageService
    {
        private readonly IPageDao _pageDao = Container.CommonContainer.Resolve<IPageDao>();

        #region BussinessExpection
        /// <summary>
        /// 页面名称已存在
        /// </summary>
        private string ERROR_PAGENAME_EXIST
        {
            get { return "ERROR_PAGENAME_EXIST"; }
        }

        /// <summary>
        /// 页面Url已存在
        /// </summary>
        private string ERROR_PAGEURL_EXIST
        {
            get { return "ERROR_PAGEURL_EXIST"; }
        }

        /// <summary>
        /// 页面不存在
        /// </summary>
        private string ERROR_PAGE_NOT_EXIST
        {
            get { return "ERROR_PAGE_NOT_EXIST"; }
        }
        #endregion

        public int AddPage(Page page)
        {
            var checkPageName = _pageDao.GetPage(page.PageName);
            if (!checkPageName.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGENAME_EXIST);
            }
            var checkPageUrl = _pageDao.GetPageByUrl(page.Url);
            if (!checkPageUrl.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEURL_EXIST);
            }

            return _pageDao.AddPge(GetPagePoFromPage(page));
        }

        public void DeletePage(int id)
        {
            GetPage(id);
            _pageDao.DeletePage(id);
        }

        public void DeletePageList(List<int> ids)
        {
            _pageDao.DeletePages(ids);
        }

        public void UpdatePage(Page page)
        {
            var checkPageName = _pageDao.GetPageWithoutId(page.Id, page.PageName);
            if (!checkPageName.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGENAME_EXIST);
            }
            var checkPageUrl = _pageDao.GetPageByUrlWithoutId(page.Id, page.Url);
            if (!checkPageUrl.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEURL_EXIST);
            }

            _pageDao.UpdatePage(GetPagePoFromPage(page));
        }

        public void UpdatePageName(int id, string pageName)
        {
            var checkPageName = _pageDao.GetPageWithoutId(id, pageName);
            if (!checkPageName.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGENAME_EXIST);
            }

            _pageDao.UpdatePageName(id, pageName);
        }

        public void UpdatePageUrl(int id, string url)
        {
            var checkPageUrl = _pageDao.GetPageByUrlWithoutId(id, url);
            if (!checkPageUrl.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEURL_EXIST);
            }

            _pageDao.UpdatePageUrl(id, url);
        }

        public void UpdatePageDomain(int id, string domain)
        {
            _pageDao.UpdatePageDomain(id, domain);
        }

        public Page GetPage(int id)
        {
            var page = GetPageFromPagePo(_pageDao.GetPage(id));
            if (page.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGE_NOT_EXIST);
            }
            return page;
        }

        public IList<Page> GetPageList()
        {
            return _pageDao.GetPageList().Select(GetPageFromPagePo).ToList();
        }

        public IList<string> GetPageUrlList()
        {
            var pages = DataCache.Get<List<string>>(CacheKey.KeyAllPage);
            if (pages.IsNullOrEmpty())
            {
                pages = GetPageList().Select(page => page.Url).ToList();
                DataCache.Insert(CacheKey.KeyAllPage, pages);
            }
            return pages;
        }

        public IList<PageView> GetPageViewList(string orderStr)
        {
            return _pageDao.GetPageViewList(orderStr).Select(GetPageViewVoFromPo).ToList();
        }

        public IList<ModulePage> GetModulePages()
        {
            var modulePages = DataCache.Get<List<ModulePage>>(CacheKey.KeyModulePages);
            if (modulePages.IsNullOrEmpty())
            {
                modulePages = GetModulePageVoFromPo(_pageDao.GetPageViewList(null).ToList());
                DataCache.Insert(CacheKey.KeyModulePages, modulePages);
            }
            return modulePages;
        }

        public IList<Page> GetPageListByUserId(int userId)
        {
            throw new System.NotImplementedException();
        }

        public IList<Page> GetPageListByRoleId(int roleId)
        {
            throw new System.NotImplementedException();
        }

        #region 辅助方法
        internal static Page GetPageFromPagePo(PagePo pagePo)
        {
            Page page = null;
            if (!pagePo.IsNullOrEmpty())
            {
                page = new Page
                    {
                        Id = pagePo.Id,
                        ModuleId = pagePo.ModuleId,
                        PageName = pagePo.PageName,
                        Url = pagePo.Url,
                        Domain = pagePo.Domain
                    };
            }
            return page;
        }

        internal static PagePo GetPagePoFromPage(Page page)
        {
            PagePo pagePo = null;
            if (!page.IsNullOrEmpty())
            {
                pagePo = new PagePo
                    {
                        Id = page.Id,
                        ModuleId = page.ModuleId,
                        PageName = page.PageName,
                        Url = page.Url,
                        Domain = page.Domain
                    };
            }
            return pagePo;
        }

        internal static PageView GetPageViewVoFromPo(PageViewPo pageViewPo)
        {
            PageView pageView = null;
            if (!pageViewPo.IsNullOrEmpty())
            {
                pageView = new PageView
                    {
                        Id = pageViewPo.Id,
                        ModuleId = pageViewPo.ModuleId,
                        ModuleName = pageViewPo.ModuleName,
                        PageName = pageViewPo.PageName,
                        Url = pageViewPo.Url,
                        Domain = pageViewPo.Domain
                    };
            }
            return pageView;
        }

        internal static List<ModulePage> GetModulePageVoFromPo(List<PageViewPo> pageViewPos)
        {
            var modulePages = new List<ModulePage>();
            foreach (var pageViewPo in pageViewPos)
            {
                var module = modulePages.FindLast(modulePage => modulePage.Module.Id == pageViewPo.ModuleId);
                if (module.IsNullOrEmpty())
                {
                    var modulePage = new ModulePage
                        {
                            Module = new Model.Module
                                {
                                    Id = pageViewPo.ModuleId,
                                    ModuleName = pageViewPo.ModuleName,
                                },
                            Pages = new List<Page>
                                {
                                    new Page
                                        {
                                            Id = pageViewPo.Id,
                                            ModuleId = pageViewPo.ModuleId,
                                            PageName = pageViewPo.PageName,
                                            Url = pageViewPo.Url,
                                            Domain = pageViewPo.Domain
                                        }
                                }
                        };
                    modulePages.Add(modulePage);
                }
                else
                {
                    module.Pages.Add(new Page
                    {
                        Id = pageViewPo.Id,
                        ModuleId = pageViewPo.ModuleId,
                        PageName = pageViewPo.PageName,
                        Url = pageViewPo.Url,
                        Domain = pageViewPo.Domain
                    });
                }
            }
            return modulePages;
        }
        #endregion
    }
}