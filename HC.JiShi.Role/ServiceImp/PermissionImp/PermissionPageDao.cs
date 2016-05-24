using System;
using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using IBatisNet.Common;

namespace HC.JiShi.UserRole.ServiceImp.PermissionImp
{
    public class PermissionPageDao : IPermissionPageDao
    {
        public int AddPermissionPage(PermissionPagePo permissionPagePo)
        {
            Object obj = Mapper.GetMaper.Insert("AddPermissionPage", permissionPagePo);
            return (int)obj;
        }

        public void AddPermissionPage(List<PermissionPagePo> permissionPagePos)
        {
            if (permissionPagePos.Count > 0)
                using(IDalSession session = Mapper.GetMaper.BeginTransaction())
                {
                    DeletePermissionPageByRoleId(permissionPagePos[0].UserRoleId);
                    Mapper.GetMaper.Insert("AddPermissionPages", permissionPagePos);
                    session.Complete();
                }
        }

        public void DeletePermissionPage(int id)
        {
            Mapper.GetMaper.Delete("DeletePermissionPage", id);
        }

        public void DeletePermissionPages(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeletePermissionPages", ids);
        }

        public void DeletePermissionPageByRoleId(int roleId)
        {
            var htPram = new Hashtable
                {
                    {"RoleId", roleId}, {"Type", (int) PermissionType.RoleId}
                };
            Mapper.GetMaper.Delete("DeletePermissionPageByRoleId", htPram);
        }

        public void UpdatePermissionPagePageId(int id, int pageId)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageId", pageId } };
            Mapper.GetMaper.Update("UpdatePermissionPagePageId", htPram);
        }
    }
}