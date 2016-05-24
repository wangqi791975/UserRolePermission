using System;
using System.Collections.Generic;
using Autofac;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using HC.JiShi.UserRole.ServiceImp.PageActionImp;
using HC.JiShi.UserRole.ServiceImp.PageImp;
using HC.JiShi.UserRole.ServiceImp.PermissionImp;
using HC.JiShi.UserRole.ServiceImp.RoleImp;
using System.Linq;
using HC.JiShi.UserRole.ServiceImp.UserImp;
using HC.JiShi.UserRole.ServiceImp.UserRoleImp;
using IBatisNet.Common;

namespace HC.JiShi.UserRole.ServiceImp
{
    public class RoleService : IRoleService
    {
        private readonly IUserDao _userDao = Container.CommonContainer.Resolve<IUserDao>();
        private readonly IRoleDao _roleDao = Container.CommonContainer.Resolve<IRoleDao>();
        private readonly IUserRoleDao _userRoleDao = Container.CommonContainer.Resolve<IUserRoleDao>();


        #region BussinessExpection
        /// <summary>
        /// 角色名称已存在
        /// </summary>
        private string ERROR_ROLENAME_EXIST
        {
            get { return "ERROR_ROLENAME_EXIST"; }
        }

        /// <summary>
        /// 用户不存在
        /// </summary>
        private string ERROR_ROLE_NOT_EXIST
        {
            get { return "ERROR_ROLE_NOT_EXIST"; }
        }

        #endregion

        //todo unitestd
        public int AddRole(Role role)
        {
            var checkRole = _roleDao.GetRole(role.RoleName);
            if (!checkRole.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_ROLENAME_EXIST);
            }
            return _roleDao.AddRole(GetRolePoFromRole(role));
        }

        //todo unitestd
        public void DeleteRole(int id)
        {
            GetRole(id);
            _roleDao.DeleteRole(id);
        }

        //todo unitestd
        public void DeleteRoles(List<int> ids)
        {
            _roleDao.DeleteRoles(ids);
        }

        //todo unitestd
        public void UpdateRole(Role role)
        {
            var checkRole = _roleDao.GetRoleWithoutId(role.Id, role.RoleName);
            if (!checkRole.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_ROLENAME_EXIST);
            }
            _roleDao.UpdateRole(GetRolePoFromRole(role));
        }

        //todo unitestd
        public void UpdateRole(int id, string roleName)
        {
            var checkRole = _roleDao.GetRoleWithoutId(id, roleName);
            if (!checkRole.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_ROLENAME_EXIST);
            }
            _roleDao.UpdateRole(id, roleName);
        }

        //todo unitestd
        public void UpdateRoleIsAdmin(int id)
        {
            _roleDao.UpdateRoleIsAdmin(id, true);
        }

        //todo unitestd
        public void UpdateRoleIsAdmin(List<int> ids)
        {
            _roleDao.UpdateRoleIsAdmin(ids, true);
        }

        //todo unitestd
        public void UpdateRoleIsNotAdmin(int id)
        {
            _roleDao.UpdateRoleIsAdmin(id, false);
        }

        //todo unitestd
        public void UpdateRoleIsNotAdmin(List<int> ids)
        {
            _roleDao.UpdateRoleIsAdmin(ids, false);
        }

        //todo unitestd
        public void UpdateRoleIsValid(int id)
        {
            _roleDao.UpdateRoleIsValid(id, true);
        }

        //todo unitestd
        public void UpdateRoleIsValid(List<int> ids)
        {
            _roleDao.UpdateRoleIsValid(ids, true);
        }

        //todo unitestd
        public void UpdateRoleIsNotValid(int id)
        {
            _roleDao.UpdateRoleIsValid(id, false);
        }

        //todo unitestd
        public void UpdateRoleIsNotValid(List<int> ids)
        {
            _roleDao.UpdateRoleIsValid(ids, false);
        }

        //todo unitestd
        public Role GetRole(int id)
        {
            var role = GetRoleFromRolePo(_roleDao.GetRole(id));
            if (role.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_ROLE_NOT_EXIST);
            }
            return role;
        }

        //todo unitestd
        public List<Role> GetRoleList(string strOrder)
        {
            return _roleDao.GetRoleList(strOrder).Select(GetRoleFromRolePo).ToList();
        }

        public RoleUsers GetRoleUsers(int roleId)
        {
            var roleUsers = new RoleUsers
                {
                    Role = GetRole(roleId),
                    Users = _userDao.GetUserList(roleId).Select(UserService.GetUserFromUserPo).ToList()
                };
            return roleUsers;
        }

        public RoleUsers GetNotInRoleUsers(int roleId)
        {
            var roleUsers = new RoleUsers
            {
                Role = GetRole(roleId),
                Users = _userDao.GetUserListNotInRole(roleId).Select(UserService.GetUserFromUserPo).ToList()
            };
            return roleUsers;
        }

        public void BindRoleUser(int roleId, int userId)
        {
            var userRolePo = new UserRolePo
            {
                UserId = userId,
                RoleId = roleId
            };
            _userRoleDao.AddUserRole(userRolePo);
        }

        public void BindRoleUser(int roleId, List<int> userIds)
        {
            var userRolePos = userIds.Select(userId => new UserRolePo
             {
                 UserId = userId,
                 RoleId = roleId
             }).ToList();
            _userRoleDao.AddUserRole(userRolePos);
        }

        public void UnBindRoleUser(int roleId)
        {
            _userRoleDao.DeleteUserRoleByRoleId(roleId);
        }


        #region 辅助方法
        internal static Role GetRoleFromRolePo(RolePo rolePo)
        {
            Role role = null;
            if (!rolePo.IsNullOrEmpty())
            {
                role = new Role
                    {
                        Id = rolePo.Id,
                        RoleName = rolePo.RoleName,
                        IsAdmin = rolePo.IsAdmin,
                        IsValid = rolePo.IsValid,
                        CreateDate = rolePo.CreateDate
                    };
            }
            return role;
        }

        internal static RolePo GetRolePoFromRole(Role role)
        {
            RolePo rolePo = null;
            if (!role.IsNullOrEmpty())
            {
                rolePo = new RolePo
                    {
                        Id = role.Id,
                        RoleName = role.RoleName,
                        IsAdmin = role.IsAdmin,
                        IsValid = role.IsValid,
                        CreateDate = role.CreateDate
                    };
            }
            return rolePo;
        }
        #endregion
    }
}