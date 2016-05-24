using System;
using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.RoleImp
{
    public class RoleDao : IRoleDao
    {
        public int AddRole(RolePo rolePo)
        {
            Object obj = Mapper.GetMaper.Insert("AddRole", rolePo);
            return (int)obj;
        }

        public void DeleteRole(int id)
        {
            Mapper.GetMaper.Delete("DeleteRole", id);
        }

        public void DeleteRoles(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeleteRoles", ids);
        }

        public void UpdateRole(RolePo rolePo)
        {
            Mapper.GetMaper.Update("UpdateRole", rolePo);
        }

        public void UpdateRole(int id, string roleName)
        {
            var htPram = new Hashtable { { "Id", id }, { "RoleName", roleName } };
            Mapper.GetMaper.Update("UpdateRoleName", htPram);
        }

        public void UpdateRoleIsAdmin(int id, bool isAdmin)
        {
            var htPram = new Hashtable { { "Id", id }, { "IsAdmin", isAdmin } };
            Mapper.GetMaper.Update("UpdateRoleIsAdmin", htPram);
        }

        public void UpdateRoleIsAdmin(List<int> ids, bool isAdmin)
        {
            var htPram = new Hashtable { { "Ids", ids }, { "IsAdmin", isAdmin } };
            Mapper.GetMaper.Update("UpdateRolesIsAdmin", htPram);
        }

        public void UpdateRoleIsValid(int id, bool isValid)
        {
            var htPram = new Hashtable { { "Id", id }, { "IsValid", isValid } };
            Mapper.GetMaper.Update("UpdateRoleIsValid", htPram);
        }

        public void UpdateRoleIsValid(List<int> ids, bool isValid)
        {
            var htPram = new Hashtable { { "Ids", ids }, { "IsValid", isValid } };
            Mapper.GetMaper.Update("UpdateRolesIsValid", htPram);
        }

        public RolePo GetRole(int id)
        {
            return Mapper.GetMaper.QueryForObject<RolePo>("GetRoleById", id);
        }

        public RolePo GetRole(string name)
        {
            return Mapper.GetMaper.QueryForObject<RolePo>("GetRoleByName", name);
        }

        public RolePo GetRoleWithoutId(int id, string name)
        {
            var htPram = new Hashtable { { "Id", id }, { "RoleName", name } };
            return Mapper.GetMaper.QueryForObject<RolePo>("GetRoleWithoutId", htPram);
        }

        public IList<RolePo> GetRoleList(string strOrder)
        {
            var htPram = new Hashtable { { "OrderString", strOrder } };
            return Mapper.GetMaper.QueryForList<RolePo>("GetAllRoles", htPram);
        }

        public IList<RolePo> GetRoleList(int userId)
        {
            return Mapper.GetMaper.QueryForList<RolePo>("GetRoleListByUserId", userId);
        }

        public IList<RolePermissionPagePo> GetRolePermissionPageList()
        {
            const int type = (int)PermissionType.RoleId;
            return Mapper.GetMaper.QueryForList<RolePermissionPagePo>("RolePermissionPageByType", type);
        }

        public IList<RolePermissionPageActionPo> GetRolePermissionPageActionList()
        {
            const int type = (int)PermissionType.RoleId;
            return Mapper.GetMaper.QueryForList<RolePermissionPageActionPo>("RolePermissionPageActionByType", type);
        }
    }
}