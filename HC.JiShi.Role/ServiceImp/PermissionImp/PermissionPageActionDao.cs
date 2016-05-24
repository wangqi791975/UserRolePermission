using System;
using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.PermissionImp
{
    public class PermissionPageActionDao : IPermissionPageActionDao
    {
        public int AddPermissionPageAction(PermissionPageActionPo permissionPageActionPo)
        {
            Object obj = Mapper.GetMaper.Insert("AddPermissionPageAction", permissionPageActionPo);
            return (int)obj;
        }

        public void AddPermissionPageAction(List<PermissionPageActionPo> permissionPageActionPos)
        {
            Mapper.GetMaper.Insert("AddPermissionPageActions", permissionPageActionPos);
        }

        public void DeletePermissionPageAction(int id)
        {
            Mapper.GetMaper.Delete("DeletePermissionPageAction", id);
        }

        public void DeletePermissionPageActions(List<int> ids)
        {
            Mapper.GetMaper.Delete("DeletePermissionPageActions", ids);
        }

        public void UpdatePermissionPageActionPageActionId(int id, int pageActionId)
        {
            var htPram = new Hashtable { { "Id", id }, { "PageActionId", pageActionId } };
            Mapper.GetMaper.Update("UpdatePermissionPageActionPageActionId", htPram);
        }
    }
}