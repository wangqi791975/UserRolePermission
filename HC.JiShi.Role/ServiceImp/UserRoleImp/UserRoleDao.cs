using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using IBatisNet.Common;

namespace HC.JiShi.UserRole.ServiceImp.UserRoleImp
{
    public class UserRoleDao : IUserRoleDao
    {
        public int AddUserRole(UserRolePo userRole)
        {
            object obj = Mapper.GetMaper.Insert("AddUserRole", userRole);
            return (int)obj;
        }

        public void AddUserRole(List<UserRolePo> userRoles)
        {
            if (userRoles.Count > 0)
                using (IDalSession session = Mapper.GetMaper.BeginTransaction())
                {
                    DeleteUserRoleByRoleId(userRoles[0].RoleId);
                    Mapper.GetMaper.Insert("AddUserRoles", userRoles);
                    session.Complete();
                }
        }

        public void DeleteUserRole(int id)
        {
            Mapper.GetMaper.Delete("DeleteUserRole", id);
        }

        public void DeleteUserRole(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeleteUserRoles", ids);
        }

        public void DeleteUserRoleByUserId(int userId)
        {
            Mapper.GetMaper.Delete("DeleteUserRoleByUserId", userId);
        }

        public void DeleteUserRoleByRoleId(int roleId)
        {
            Mapper.GetMaper.Delete("DeleteUserRoleByRoleId", roleId);
        }

        public void UpdateUserRole(UserRolePo userRole)
        {
            Mapper.GetMaper.Delete("UpdateUserRole", userRole);
        }
    }
}