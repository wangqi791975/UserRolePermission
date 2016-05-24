using System.Collections;
using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;
using IBatisNet.DataMapper;
using Mapper = HC.JiShi.UserRole.Common.Mapper;

namespace HC.JiShi.UserRole.ServiceImp.ModuleImp
{
    public class ModuleDao : IModuleDao
    {
        readonly ISqlMapper _maper = Mapper.GetMaper;
        public int AddModule(ModulePo modulePo)
        {
            return (int)_maper.Insert("AddModule", modulePo);
        }

        public void DeleteModule(int id)
        {
            _maper.Delete("DeleteModule", id);
        }

        public void UpdateModule(ModulePo modulePo)
        {
            _maper.Update("UpdateModule", modulePo);
        }

        public ModulePo GetModule(int id)
        {
            return _maper.QueryForObject<ModulePo>("GetModule", id);
        }

        public IList<ModulePo> GetModuleList(string orderStr)
        {
            var htPram = new Hashtable { { "OrderString", orderStr } };
            return _maper.QueryForList<ModulePo>("GetModuleList", htPram);
        }

        public ModulePo GetModule(string name)
        {
            return _maper.QueryForObject<ModulePo>("GetModuleByName", name);
        }

        public ModulePo GetModuleWithOutId(int id, string name)
        {
            var htPram = new Hashtable { { "Id", id }, { "ModuleName", name } };
            return _maper.QueryForObject<ModulePo>("GetModuleWithOutId", htPram);
        }
    }
}