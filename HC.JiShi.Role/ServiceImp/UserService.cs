using System;
using System.Collections;
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
using HC.JiShi.UserRole.ServiceImp.UserImp;
using System.Linq;
using HC.JiShi.UserRole.ServiceImp.UserRoleImp;
using HC.Jishi.Common;

namespace HC.JiShi.UserRole.ServiceImp
{
    public class UserService : IUserService
    {
        private const string Key = "w@wjw.cn";
        private readonly IUserDao _userDao = Container.CommonContainer.Resolve<IUserDao>();
        private readonly IRoleDao _roleDao = Container.CommonContainer.Resolve<IRoleDao>();
        private readonly IUserRoleDao _userRoleDao = Container.CommonContainer.Resolve<IUserRoleDao>();

        #region BussinessExpection
        /// <summary>
        /// 用户名已存在
        /// </summary>
        private string ERROR_USERNAME_EXIST
        {
            get { return "ERROR_USERNAME_EXIST"; }
        }

        /// <summary>
        /// 用户不存在
        /// </summary>
        private string ERROR_USER_NOT_EXIST
        {
            get { return "ERROR_USER_NOT_EXIST"; }
        }

        /// <summary>
        /// 两次密码输入不一致
        /// </summary>
        private string ERROR_TWO_INPUT_PASSWORD_DIFFERENT
        {
            get { return "ERROR_TWO_INPUT_PASSWORD_DIFFERENT"; }
        }

        /// <summary>
        /// 用户名密码不正确
        /// </summary>
        private string ERROR_USERNAME_OR_PASSWORD
        {
            get { return "ERROR_USERNAME_OR_PASSWORD"; }
        }

        /// <summary>
        /// 新旧密码一致
        /// </summary>
        private string ERROR_NEW_OLD_PASSOWRD_SAME
        {
            get { return "ERROR_NEW_OLD_PASSOWRD_SAME"; }
        }

        /// <summary>
        /// 密码长度不能超过32
        /// </summary>
        private string ERROR_PWD_LEN_MORE_THAN_32
        {
            get { return "ERROR_PWD_LEN_MORE_THAN_32"; }
        }
        #endregion

        //todo unitested
        public int AddUser(User user)
        {
            var checkUser = _userDao.GetUser(user.UserName);
            //判断用户名是否存在
            if (!checkUser.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_USERNAME_EXIST);
            }

            user.Password = DEncrypt.Encrypt(user.Password, Key);

            Object obj = _userDao.AddUser(GetUserPoFromUser(user));
            return (int)obj;
        }

        //todo unitested
        public void DeleteUser(int id)
        {
            _userDao.DeleteUser(id);
        }

        //todo unitested
        public void DeleteUsers(List<int> ids)
        {
            _userDao.DeleteUsers(ids);
        }

        //todo unitested
        public void UpdateUser(User user)
        {
            var checkUser = _userDao.GetUserWithoutId(user.Id, user.UserName);
            //判断用户名是否存在
            if (!checkUser.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_USERNAME_EXIST);
            }

            _userDao.UpdateUser(GetUserPoFromUser(user));
        }

        //todo unitested
        public void UpdateUserName(int id, string newUserName)
        {
            var checkUser = _userDao.GetUserWithoutId(id, newUserName);
            //判断用户名是否存在
            if (!checkUser.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_USERNAME_EXIST);
            }

            _userDao.UpdateUserName(id, newUserName);
        }

        //todo unitested
        public void UpdatePassword(int id, string oldPassword, string newPassword, string reNewPassword)
        {

            string enOldPwd = DEncrypt.Encrypt(oldPassword, Key);
            string enNewPwd = DEncrypt.Encrypt(newPassword, Key);

            if (newPassword != reNewPassword)
            {
                throw new BussinessException(ERROR_TWO_INPUT_PASSWORD_DIFFERENT);
            }

            if (newPassword.Length >= 32)
            {
                throw new BussinessException(ERROR_PWD_LEN_MORE_THAN_32);
            }

            var user = GetUser(id);
            if (user.Password != enOldPwd)
            {
                throw new BussinessException(ERROR_USERNAME_OR_PASSWORD);
            }

            if (user.Password == enNewPwd)
            {
                throw new BussinessException(ERROR_NEW_OLD_PASSOWRD_SAME);
            }

            _userDao.UpdatePassword(id, enNewPwd);
        }

        public void ResetPassword(int userId, string password)
        {
            if (password.Length >= 32)
            {
                throw new BussinessException(ERROR_PWD_LEN_MORE_THAN_32);
            }
            string enNewPwd = DEncrypt.Encrypt(password, Key);
            _userDao.UpdatePassword(userId, enNewPwd);
        }

        //todo unitested
        public User GetUser(int id)
        {
            var user = GetUserFromUserPo(_userDao.GetUser(id));
            if (user.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_USER_NOT_EXIST);
            }
            return user;
        }

        //todo unitested
        public IList<User> GetUserList(string strOrder)
        {
            return _userDao.GetUserList(strOrder).Select(GetUserFromUserPo).ToList();
        }

        public UserRoles GetUserRoles(int userId)
        {
            var userRoles = new UserRoles
                {
                    User = GetUser(userId),
                    Roles = _roleDao.GetRoleList(userId).Select(RoleService.GetRoleFromRolePo).ToList()
                };
            return userRoles;
        }

        public void BindUserRole(int userId, int roleId)
        {
            var userRolePo = new UserRolePo
                {
                    UserId = userId,
                    RoleId = roleId
                };
            _userRoleDao.AddUserRole(userRolePo);
        }

        public void BindUserRole(int userId, List<int> roleIds)
        {
            var userRolePos = roleIds.Select(roleId => new UserRolePo
               {
                   UserId = userId,
                   RoleId = roleId
               }).ToList();
            _userRoleDao.AddUserRole(userRolePos);
        }

        public User Login(string userName, string password)
        {
            string enPwd = DEncrypt.Encrypt(password, Key);
            var user = GetUserFromUserPo(_userDao.GetUserByUserNameAndPassword(userName, enPwd));
            if (!user.IsValid)
                return null;
            return user;
        }

        #region 辅助方法
        internal static User GetUserFromUserPo(UserPo userPo)
        {
            User user = null;
            if (!userPo.IsNullOrEmpty())
            {
                var roleDao = Container.CommonContainer.Resolve<IRoleDao>();
                bool roleIsAdmin = roleDao.GetRoleList(userPo.Id).Any(rolePo => rolePo.IsAdmin);
                user = new User
                    {
                        Id = userPo.Id,
                        UserName = userPo.UserName,
                        Password = userPo.Password,
                        IsAdmin = userPo.IsAdmin,
                        RoleIsAdmin = roleIsAdmin,
                        IsValid = userPo.IsValid,
                        CreateDate = userPo.CreateDate
                    };
            }
            return user;
        }

        internal static UserPo GetUserPoFromUser(User user)
        {
            UserPo userPo = null;
            if (!user.IsNullOrEmpty())
            {
                userPo = new UserPo
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Password = user.Password,
                    IsAdmin = user.IsAdmin,
                    IsValid = user.IsValid,
                    CreateDate = user.CreateDate
                };
            }
            return userPo;
        }
        #endregion

    }
}