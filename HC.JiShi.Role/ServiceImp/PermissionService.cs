using System.Collections.Generic;
using System.Linq;
using Autofac;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using HC.JiShi.UserRole.ServiceImp.PageActionImp;
using HC.JiShi.UserRole.ServiceImp.PageImp;
using HC.JiShi.UserRole.ServiceImp.PermissionImp;
using HC.JiShi.UserRole.ServiceImp.RoleImp;
using HC.JiShi.UserRole.ServiceImp.UserImp;
using HC.Jishi.UserRole.Common;

namespace HC.JiShi.UserRole.ServiceImp
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionPageDao _permissionPageDao = Container.CommonContainer.Resolve<IPermissionPageDao>();
        private readonly IPermissionPageActionDao _permissionPageActionDao = Container.CommonContainer.Resolve<IPermissionPageActionDao>();
        private readonly IPageDao _pageDao = Container.CommonContainer.Resolve<IPageDao>();
        private readonly IPageActionDao _pageActionDao = Container.CommonContainer.Resolve<IPageActionDao>();
        private readonly IUserDao _userDao = Container.CommonContainer.Resolve<IUserDao>();
        private readonly IRoleDao _roleDao = Container.CommonContainer.Resolve<IRoleDao>();

        #region BussinessExpection

        #endregion

        #region User
        public int BindUserPermissionPage(int userId, int pageId)
        {
            return _permissionPageDao.AddPermissionPage(new PermissionPagePo
            {
                Type = (int)PermissionType.UserId,
                PageId = pageId,
                UserRoleId = userId
            });
        }

        public void BindUserPermissionPage(int userId, List<int> pageIds)
        {
            var permissionPagePos = pageIds.Select(pageId => new PermissionPagePo
            {
                Type = (int)PermissionType.UserId,
                PageId = pageId,
                UserRoleId = userId
            }).ToList();
            _permissionPageDao.AddPermissionPage(permissionPagePos);
        }

        public int BindUserPermissionPageAction(int userId, int pageActionId)
        {
            return _permissionPageActionDao.AddPermissionPageAction(new PermissionPageActionPo
            {
                Type = (int)PermissionType.UserId,
                PageActionId = pageActionId,
                UserRoleId = userId
            });
        }

        public void BindUserPermissionPageAction(int userId, List<int> pageActionIds)
        {
            var permissionPageActionPos = pageActionIds.Select(pageActionId => new PermissionPageActionPo
            {
                Type = (int)PermissionType.UserId,
                PageActionId = pageActionId,
                UserRoleId = userId
            }).ToList();
            _permissionPageActionDao.AddPermissionPageAction(permissionPageActionPos);
        }

        public UserPermissionPage GetUserPermissionPage(int userId)
        {
            var userPermisssionPage = DataCache.Get<UserPermissionPage>(CacheKey.KeyUserPermissionPage + userId);

            if (userPermisssionPage.IsNullOrEmpty())
            {
                userPermisssionPage = new UserPermissionPage
                {
                    UserId = userId,
                    Pages = _pageDao.GetPageListByUserId(userId).Select(PageService.GetPageFromPagePo).ToList()
                };

                var roles = _roleDao.GetRoleList(userId).Where(role => role.IsValid);
                foreach (var role in roles)
                {
                    var rolePermissionPage = new RolePermissionPage
                        {
                            RoleId = role.Id,
                            Pages = _pageDao.GetPageListByRoleId(role.Id).Select(PageService.GetPageFromPagePo).ToList()
                        };
                    foreach (var page in rolePermissionPage.Pages)
                    {
                        if (!userPermisssionPage.Pages.Select(p => p.Id).ToList().Contains(page.Id))
                        {
                            userPermisssionPage.Pages.Add(page);
                        }
                    }
                }
                DataCache.Insert(CacheKey.KeyUserPermissionPage + userId, userPermisssionPage);
            }
            return userPermisssionPage;
        }

        public IList<string> GetUserPermissionPageUrl(int userId)
        {
            var userPageUrls = DataCache.Get<List<string>>(CacheKey.KeyUserPageUrl + userId);
            if (userPageUrls.IsNullOrEmpty())
            {
                userPageUrls = GetUserPermissionPage(userId).Pages.Select(page => page.Url).ToList();
                DataCache.Insert(CacheKey.KeyUserPageUrl + userId, userPageUrls, 30);
            }
            return userPageUrls;
        }

        public IList<UserPermissionPage> GetUserPermissionPage()
        {
            var userPermissionPagePos = _userDao.GetUserPermissionPageList().ToList();
            return GetUserPermissionPagesVoFromPo(userPermissionPagePos);
        }

        public UserPermissionPageAction GetUserPermissionPageAction(int userId)
        {
            var userPermissionPageAction = new UserPermissionPageAction
            {
                UserId = userId,
                PageActions = _pageActionDao.GetPageActionListByUserId(userId)
                                  .Select(PageActionService.GetPageActionFromPageActionPo)
                                  .ToList()
            };
            return userPermissionPageAction;
        }

        public IList<UserPermissionPageAction> GetUserPermissionPageAction()
        {
            var userPermissionPageActions = _userDao.GetUserPermissionPageActionList().ToList();
            return GetUserPermissionPageActionsVoFromPo(userPermissionPageActions);
        }
        #endregion

        #region Role
        public int BindRolePermissionPage(int roleId, int pageId)
        {
            return _permissionPageDao.AddPermissionPage(new PermissionPagePo
            {
                Type = (int)PermissionType.RoleId,
                PageId = pageId,
                UserRoleId = roleId
            });
        }

        public void BindRolePermissionPage(int roleId, List<int> pageIds)
        {
            var permissionPagePos = pageIds.Select(pageId => new PermissionPagePo
            {
                Type = (int)PermissionType.RoleId,
                PageId = pageId,
                UserRoleId = roleId
            }).ToList();
            _permissionPageDao.AddPermissionPage(permissionPagePos);
        }

        public void UnBindRolePermissionPage(int roleId)
        {
            _permissionPageDao.DeletePermissionPageByRoleId(roleId);
        }

        public int BindRolePermissionPageAction(int roleId, int pageActionId)
        {
            return _permissionPageActionDao.AddPermissionPageAction(new PermissionPageActionPo
            {
                Type = (int)PermissionType.RoleId,
                PageActionId = pageActionId,
                UserRoleId = roleId
            });
        }

        public void BindRolePermissionPageAction(int roleId, List<int> pageActionIds)
        {
            var permissionPageActionPos = pageActionIds.Select(pageActionId => new PermissionPageActionPo
            {
                Type = (int)PermissionType.RoleId,
                PageActionId = pageActionId,
                UserRoleId = roleId
            }).ToList();
            _permissionPageActionDao.AddPermissionPageAction(permissionPageActionPos);
        }

        public RolePermissionPage GetRolePermissionPage(int roleId)
        {
            var rolePermissionPage = new RolePermissionPage
            {
                RoleId = roleId,
                Pages = _pageDao.GetPageListByRoleId(roleId).Select(PageService.GetPageFromPagePo).ToList()
            };
            return rolePermissionPage;
        }

        public List<RolePermissionPage> GetRolePermissionPage()
        {
            var rolePermissionPagePos = _roleDao.GetRolePermissionPageList().ToList();
            return GetRolePermissionPagesVoFromPo(rolePermissionPagePos);
        }

        public RolePermissionPageAction GetRolePermissionPageAction(int roleId)
        {
            var rolePermissionPageAction = new RolePermissionPageAction
            {
                RoleId = roleId,
                PageActions =
                    _pageActionDao.GetPageActionListByRoleId(roleId)
                                  .Select(PageActionService.GetPageActionFromPageActionPo)
                                  .ToList()
            };
            return rolePermissionPageAction;
        }

        public List<RolePermissionPageAction> GetRolePermissionPageAction()
        {
            var rolePermissionPageActionPos = _roleDao.GetRolePermissionPageActionList().ToList();
            return GetRolePermissionPageActionsVoFromPo(rolePermissionPageActionPos);
        }
        #endregion

        #region 辅助方法
        internal static List<UserPermissionPage> GetUserPermissionPagesVoFromPo(List<UserPermissionPagePo> userPermissionPagePos)
        {
            var userPermissionPages = new List<UserPermissionPage>();
            foreach (var userPermissionPagePo in userPermissionPagePos)
            {
                var userPermissionPage = userPermissionPages.FindLast(m => m.UserId == userPermissionPagePo.UserId);
                if (!userPermissionPage.IsNullOrEmpty())
                {
                    userPermissionPage.Pages.Add(new Page
                        {
                            Id = userPermissionPagePo.PageId,
                            PageName = userPermissionPagePo.PageName,
                            Url = userPermissionPagePo.Url,
                            Domain = userPermissionPagePo.Domain
                        });
                }
                else
                {
                    userPermissionPages.Add(new UserPermissionPage
                        {
                            UserId = userPermissionPagePo.UserId,
                            Pages = new List<Page>{new Page
                                {
                                    Id = userPermissionPagePo.PageId,
                                    PageName = userPermissionPagePo.PageName,
                                    Url = userPermissionPagePo.Url,
                                    Domain = userPermissionPagePo.Domain
                                }
                            }
                        });
                }
            }
            return userPermissionPages;
        }

        internal static List<UserPermissionPageAction> GetUserPermissionPageActionsVoFromPo(List<UserPermissionPageActionPo> userPermissionPageActionPos)
        {
            var userPermissionPageActions = new List<UserPermissionPageAction>();
            foreach (var userPermissionPageActionPo in userPermissionPageActionPos)
            {
                var userPermissionPageAction = userPermissionPageActions.FindLast(m => m.UserId == userPermissionPageActionPo.UserId);
                if (!userPermissionPageAction.IsNullOrEmpty())
                {
                    userPermissionPageAction.PageActions.Add(new PageAction
                        {
                            Id = userPermissionPageActionPo.PageActionId,
                            PageId = userPermissionPageActionPo.PageId,
                            ActionName = userPermissionPageActionPo.ActionName,
                            ActionUrl = userPermissionPageActionPo.ActionUrl
                        });
                }
                else
                {
                    userPermissionPageActions.Add(new UserPermissionPageAction
                        {
                            UserId = userPermissionPageActionPo.UserId,
                            PageActions = new List<PageAction>
                                {
                                    new PageAction
                                        {
                                            Id = userPermissionPageActionPo.PageActionId,
                                            PageId = userPermissionPageActionPo.PageId,
                                            ActionName = userPermissionPageActionPo.ActionName,
                                            ActionUrl = userPermissionPageActionPo.ActionUrl
                                        }
                                }
                        });
                }
            }
            return userPermissionPageActions;
        }

        internal static List<RolePermissionPage> GetRolePermissionPagesVoFromPo(List<RolePermissionPagePo> rolePermissionPagePos)
        {
            var rolePermissionPages = new List<RolePermissionPage>();
            foreach (var rolePermissionPagePo in rolePermissionPagePos)
            {
                var rolePermissionPage = rolePermissionPages.FindLast(m => m.RoleId == rolePermissionPagePo.RoleId);
                if (!rolePermissionPage.IsNullOrEmpty())
                {
                    rolePermissionPage.Pages.Add(new Page
                        {
                            Id = rolePermissionPagePo.PageId,
                            PageName = rolePermissionPagePo.PageName,
                            Url = rolePermissionPagePo.Url,
                            Domain = rolePermissionPagePo.Domain
                        });
                }
                else
                {
                    rolePermissionPages.Add(new RolePermissionPage
                        {
                            RoleId = rolePermissionPagePo.RoleId,
                            Pages = new List<Page>{new Page
                                {
                                    Id = rolePermissionPagePo.PageId,
                                    PageName = rolePermissionPagePo.PageName,
                                    Url = rolePermissionPagePo.Url,
                                    Domain = rolePermissionPagePo.Domain                               
                                }
                            }
                        });
                }
            }
            return rolePermissionPages;
        }

        internal static List<RolePermissionPageAction> GetRolePermissionPageActionsVoFromPo(List<RolePermissionPageActionPo> rolePermissionPageActionPos)
        {
            var rolePermissionPageActions = new List<RolePermissionPageAction>();
            foreach (var rolePermissionPageActionPo in rolePermissionPageActionPos)
            {
                var rolePermissionPageAction = rolePermissionPageActions.FindLast(m => m.RoleId == rolePermissionPageActionPo.RoleId);
                if (!rolePermissionPageAction.IsNullOrEmpty())
                {
                    rolePermissionPageAction.PageActions.Add(new PageAction
                        {
                            Id = rolePermissionPageActionPo.PageActionId,
                            PageId = rolePermissionPageActionPo.PageId,
                            ActionName = rolePermissionPageActionPo.ActionName,
                            ActionUrl = rolePermissionPageActionPo.ActionUrl
                        });
                }
                else
                {
                    rolePermissionPageActions.Add(new RolePermissionPageAction
                        {
                            RoleId = rolePermissionPageActionPo.RoleId,
                            PageActions = new List<PageAction>
                                {
                                    new PageAction
                                        {
                                            Id = rolePermissionPageActionPo.PageActionId,
                                            PageId = rolePermissionPageActionPo.PageId,
                                            ActionName = rolePermissionPageActionPo.ActionName,
                                            ActionUrl = rolePermissionPageActionPo.ActionUrl
                                        }
                                }
                        });
                }
            }
            return rolePermissionPageActions;
        }
        #endregion
    }
}