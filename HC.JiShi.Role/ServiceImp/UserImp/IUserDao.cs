using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.UserImp
{
    public interface IUserDao
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int AddUser(UserPo user);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void DeleteUser(int id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void DeleteUsers(List<int> ids);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(UserPo user);

        /// <summary>
        /// 更新用户名
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        void UpdateUserName(int id, string userName);

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        void UpdatePassword(int id, string password);

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserPo GetUser(int id);

        /// <summary>
        /// 通过用户名要获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        UserPo GetUser(string userName);

        /// <summary>
        /// 通过用户名称密码获取用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        UserPo GetUserByUserNameAndPassword(string userName, string password);

        /// <summary>
        /// 查询用户名（不包含传入Id）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        UserPo GetUserWithoutId(int id, string userName);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        IList<UserPo> GetUserList(string strOrder);

        /// <summary>
        /// 获取角色对应所有用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IList<UserPo> GetUserList(int roleId);

        /// <summary>
        /// 获取不在该角色的所有用户
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        IList<UserPo> GetUserListNotInRole(int roleId);

        /// <summary>
        /// 获取所有用户可访问的页面
        /// </summary>
        /// <returns></returns>
        IList<UserPermissionPagePo> GetUserPermissionPageList();

        /// <summary>
        /// 获取所有用户可操作的页面行为
        /// </summary>
        /// <returns></returns>
        IList<UserPermissionPageActionPo> GetUserPermissionPageActionList();
    }
}