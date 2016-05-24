using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using HC.JiShi.UserRole.ServiceImp.PageActionImp;

namespace HC.JiShi.UserRole.ServiceImp
{
    public class PageActionService : IPageActionService
    {
        private readonly IPageActionDao _pageDao = Container.CommonContainer.Resolve<IPageActionDao>();

        #region BussinessExpection
        /// <summary>
        /// 页面行为已存在
        /// </summary>
        private string ERROR_PAGEACTION_EXIST
        {
            get { return "PageAction"; }
        }

        /// <summary>
        /// 要操作的页面行为不存在
        /// </summary>
        private string ERROR_PAGEACTION_NOT_EXIST
        {
            get { return "ERROR_PAGEACTION_NOT_EXIST"; }
        }
        #endregion

        public int AddPageAction(PageAction pageAction)
        {
            var checkPageAction = _pageDao.GetPageAction(pageAction.PageId, pageAction.ActionName);
            if (!checkPageAction.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEACTION_EXIST);
            }

            return _pageDao.AddPageAction(GetPageActionPoFromPageAction(pageAction));
        }

        public void DeletePageAction(int id)
        {
            _pageDao.DeletePageAction(id);
        }

        public void DeletePageAction(List<int> ids)
        {
            _pageDao.DeletePageActions(ids);
        }

        public void UpdatePageAction(PageAction pageAction)
        {
            var checkPageAction = _pageDao.GetPageAction(pageAction.PageId, pageAction.ActionName);
            if (!checkPageAction.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEACTION_EXIST);
            }

            _pageDao.UpdatePageAction(GetPageActionPoFromPageAction(pageAction));
        }

        public void UpdatePageAction(int id, int pageId)
        {
            var pageAction = GetPageAction(id);
            var checkPageAction = _pageDao.GetPageAction(pageId, pageAction.ActionName);
            if (!checkPageAction.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEACTION_EXIST);
            }

            _pageDao.UpdatePageActionPageId(id, pageId);
        }

        public void UpdatePageActionName(int id, string pageActionName)
        {
            var pageAction = GetPageAction(id);
            var checkPageAction = _pageDao.GetPageAction(pageAction.PageId, pageActionName);
            if (!checkPageAction.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEACTION_EXIST);
            }

            _pageDao.UpdatePageActionName(id, pageActionName);
        }

        public void UpdatePageActionUrl(int id, string pageActionUrl)
        {
            _pageDao.UpdatePageActionUrl(id, pageActionUrl);
        }

        public PageAction GetPageAction(int id)
        {
            var pageAction = GetPageActionFromPageActionPo(_pageDao.GetPageAction(id));
            if (pageAction.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_PAGEACTION_NOT_EXIST);
            }

            return pageAction;
        }

        public List<PageAction> GetPageActionList()
        {
            return _pageDao.GetPageActionList().Select(GetPageActionFromPageActionPo).ToList();
        }

        public List<PageAction> GetPageActionListByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public List<PageAction> GetPageActionListByRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        #region 辅助方法
        internal static PageAction GetPageActionFromPageActionPo(PageActionPo pageActionPo)
        {
            PageAction pageAction = null;
            if (!pageActionPo.IsNullOrEmpty())
            {
                pageAction = new PageAction
                    {
                        Id = pageActionPo.Id,
                        PageId = pageActionPo.PageId,
                        ActionName = pageActionPo.ActionName,
                        ActionUrl = pageActionPo.ActionUrl
                    };
            }
            return pageAction;
        }

        internal static PageActionPo GetPageActionPoFromPageAction(PageAction pageAction)
        {
            PageActionPo pageActionPo = null;
            if (!pageAction.IsNullOrEmpty())
            {
                pageActionPo = new PageActionPo
                    {
                        Id = pageAction.Id,
                        PageId = pageAction.PageId,
                        ActionName = pageAction.ActionName,
                        ActionUrl = pageAction.ActionUrl
                    };
            }
            return pageActionPo;
        }
        #endregion
    }
}