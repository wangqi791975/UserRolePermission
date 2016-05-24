using System;
using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.UserImp
{
    public class UserDao : IUserDao
    {
        public int AddUser(UserPo user)
        {
            Object obj = Mapper.GetMaper.Insert("AddUser", user);
            return (int)obj;
        }

        public void DeleteUser(int id)
        {
            Mapper.GetMaper.Delete("DeleteUser", id);
        }

        public void DeleteUsers(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeleteUsers", ids);
        }

        public void UpdateUser(UserPo user)
        {
            Mapper.GetMaper.Update("UpdateUser", user);
        }

        public void UpdateUserName(int id, string userName)
        {
            var htPram = new Hashtable { { "Id", id }, { "UserName", userName } };
            Mapper.GetMaper.Update("UpdateUserName", htPram);
        }

        public void UpdatePassword(int id, string password)
        {
            var htPram = new Hashtable { { "Id", id }, { "Password", password } };
            Mapper.GetMaper.Update("UpdatePassword", htPram);
        }

        public UserPo GetUser(int id)
        {
            return Mapper.GetMaper.QueryForObject<UserPo>("GetUserById", id);
        }

        public UserPo GetUser(string userName)
        {
            return Mapper.GetMaper.QueryForObject<UserPo>("GetUserByUserName", userName);
        }

        public UserPo GetUserByUserNameAndPassword(string userName, string password)
        {

            var htPram = new Hashtable { { "UserName", userName }, { "Password", password } };
            return Mapper.GetMaper.QueryForObject<UserPo>("GetUserByUserNameAndPassword", htPram);
        }

        public UserPo GetUserWithoutId(int id, string userName)
        {
            var htPram = new Hashtable { { "Id", id }, { "UserName", userName } };
            return Mapper.GetMaper.QueryForObject<UserPo>("GetUserWithoutId", htPram);
        }

        public IList<UserPo> GetUserList(string strOrder)
        {
            var htPram = new Hashtable { { "OrderString", strOrder } };
            return Mapper.GetMaper.QueryForList<UserPo>("GetAllUsers", htPram);
        }

        public IList<UserPo> GetUserList(int roleId)
        {
            return Mapper.GetMaper.QueryForList<UserPo>("GetUserListByRoleId", roleId);
        }

        public IList<UserPo> GetUserListNotInRole(int roleId)
        {
            return Mapper.GetMaper.QueryForList<UserPo>("GetUserListNotInRole", roleId);
        }

        public IList<UserPermissionPagePo> GetUserPermissionPageList()
        {
            const int type = (int)PermissionType.UserId;
            return Mapper.GetMaper.QueryForList<UserPermissionPagePo>("UserPermissionPageByType", type);
        }

        public IList<UserPermissionPageActionPo> GetUserPermissionPageActionList()
        {
            const int type = (int)PermissionType.UserId;
            return Mapper.GetMaper.QueryForList<UserPermissionPageActionPo>("UserPermissionPageActionByType", type);
        }
    }
}