using System.Collections.Generic;
using HC.JiShi.UserRole.Model;

namespace HC.JiShi.UserRole.Service
{
    public interface IUserService
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int AddUser(User user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);

        /// <summary>
        /// 批量删除用户
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        void DeleteUsers(List<int> ids);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// 修改用户名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newUserName"></param>
        /// <returns></returns>
        void UpdateUserName(int id, string newUserName);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="reNewPassword"></param>
        /// <returns></returns>
        void UpdatePassword(int id, string oldPassword, string newPassword, string reNewPassword);

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        void ResetPassword(int userId, string password = "123456");

        /// <summary>
        /// 通过用户Id获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUser(int id);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        IList<User> GetUserList(string strOrder);

        /// <summary>
        /// 获取用户对应的所有角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        UserRoles GetUserRoles(int userId);

        /// <summary>
        /// 绑定用户角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleId"></param>
        void BindUserRole(int userId, int roleId);

        /// <summary>
        /// 用户绑定多个角色
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        void BindUserRole(int userId, List<int> roleIds);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Login(string userName, string password);

    }
}