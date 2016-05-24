using System;
using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PageImp
{
    public class PageDao : IPageDao
    {
        public int AddPge(PagePo pagePo)
        {
            Object obj = Mapper.GetMaper.Insert("AddPage", pagePo);
            return (int)obj;
        }

        public void DeletePage(int id)
        {
            Mapper.GetMaper.Delete("DeletePage", id);
        }

        public void DeletePages(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeletePages", ids);
        }

        public void UpdatePage(PagePo pagePo)
        {
            Mapper.GetMaper.Update("UpdatePage", pagePo);
        }

        public void UpdatePageName(int id, string pageName)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageName", pageName } };
            Mapper.GetMaper.Update("UpdatePageName", htPram);
        }

        public void UpdatePageUrl(int id, string url)
        {
            var htPram = new Hashtable { { "Id", id }, { "Url", url } };
            Mapper.GetMaper.Update("UpdatePageUrl", htPram);
        }

        public void UpdatePageDomain(int id, string domain)
        {
            var htPram = new Hashtable { { "Id", id }, { "Domain", domain } };
            Mapper.GetMaper.Update("UpdatePageDomain", htPram);
        }

        public PagePo GetPage(int id)
        {
            return Mapper.GetMaper.QueryForObject<PagePo>("GetPageById", id);
        }

        public PagePo GetPage(string pageName)
        {
            return Mapper.GetMaper.QueryForObject<PagePo>("GetPageByPageName", pageName);
        }

        public PagePo GetPageWithoutId(int id, string pageName)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageName", pageName } };
            return Mapper.GetMaper.QueryForObject<PagePo>("GetPageWithoutId", htPram);
        }

        public PagePo GetPageByUrl(string url)
        {
            return Mapper.GetMaper.QueryForObject<PagePo>("GetPageByUrl", url);
        }

        public PagePo GetPageByUrlWithoutId(int id, string url)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageName", url } };
            return Mapper.GetMaper.QueryForObject<PagePo>("GetPageByUrlWithoutId", htPram);
        }

        public IList<PagePo> GetPageList()
        {
            return Mapper.GetMaper.QueryForList<PagePo>("GetAllPages", null);
        }

        public IList<PageViewPo> GetPageViewList(string orderStr)
        {
            var htPram = new Hashtable {{"OrderString", orderStr}};
            return Mapper.GetMaper.QueryForList<PageViewPo>("GetAllPageViews", htPram);
        }

        public IList<PagePo> GetPageListByUserId(int userId)
        {
            var htPram = new Hashtable { { "Type", (int)PermissionType.UserId }, { "UserId", userId } };
            return Mapper.GetMaper.QueryForList<PagePo>("GetPageListByUserId", htPram);
        }

        public IList<PagePo> GetPageListByRoleId(int roleId)
        {
            var htPram = new Hashtable { { "Type", (int)PermissionType.RoleId }, { "RoleId", roleId } };
            return Mapper.GetMaper.QueryForList<PagePo>("GetPageListByRoleId", htPram);
        }
    }
}