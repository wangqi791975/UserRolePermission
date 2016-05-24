using System;
using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PageActionImp
{
    public class PageActionDao : IPageActionDao
    {
        public int AddPageAction(PageActionPo pageActionPo)
        {
            Object obj = Mapper.GetMaper.Insert("AddPageAction", pageActionPo);
            return (int)obj;
        }

        public void DeletePageAction(int id)
        {
            Mapper.GetMaper.Delete("DeletePageAction", id);
        }

        public void DeletePageActions(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeletePageActions", ids);
        }

        public void UpdatePageAction(PageActionPo pageActionPo)
        {
            Mapper.GetMaper.Update("UpdatePageAction", pageActionPo);
        }

        public void UpdatePageActionPageId(int id, int pageId)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageId", pageId } };
            Mapper.GetMaper.Update("UpdatePageActionPageId", htPram);
        }

        public void UpdatePageActionName(int id, string pageActionName)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageActionName", pageActionName } };
            Mapper.GetMaper.Update("UpdatePageActionName", htPram);
        }

        public void UpdatePageActionUrl(int id, string actionUrl)
        {
            var htPram = new Hashtable { { "Id", id }, { "ActionUrl", actionUrl } };
            Mapper.GetMaper.Update("UpdatePageActionUrl", htPram);
        }

        public PageActionPo GetPageAction(int id)
        {
            return Mapper.GetMaper.QueryForObject<PageActionPo>("GetPageActionById", id);
        }

        public PageActionPo GetPageAction(int pageId, string pageActionName)
        {
            var htPram = new Hashtable { { "PageId", pageId }, { "ActionName", pageActionName } };
            return Mapper.GetMaper.QueryForObject<PageActionPo>("GetPageActionByPageIdAndActioName", htPram);
        }

        public IList<PageActionPo> GetPageActionListByPageId(int pageId)
        {
            return Mapper.GetMaper.QueryForList<PageActionPo>("GetPageActionListByPageId", pageId);
        }

        public IList<PageActionPo> GetPageActionList()
        {
            return Mapper.GetMaper.QueryForList<PageActionPo>("GetAllPageActions", null);
        }

        public IList<PageActionPo> GetPageActionListByUserId(int userId)
        {
            var htPram = new Hashtable { { "Type", (int)PermissionType.UserId }, { "UserId", userId } };
            return Mapper.GetMaper.QueryForList<PageActionPo>("GetPageActionListByUserId", htPram);
        }

        public IList<PageActionPo> GetPageActionListByRoleId(int roleId)
        {
            var htPram = new Hashtable { { "Type", (int)PermissionType.UserId }, { "RoleId", roleId } };
            return Mapper.GetMaper.QueryForList<PageActionPo>("GetPageActionListByRoleId", htPram);
        }
    }
}