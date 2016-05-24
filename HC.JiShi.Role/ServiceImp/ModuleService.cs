using System.Collections.Generic;
using HC.JiShi.UserRole.Common;
using HC.JiShi.UserRole.Entity;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using HC.JiShi.UserRole.ServiceImp.ModuleImp;
using Autofac;
using System.Linq;
using Module = HC.JiShi.UserRole.Model.Module;

namespace HC.JiShi.UserRole.ServiceImp
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleDao _moduleDao = Container.CommonContainer.Resolve<IModuleDao>();

        #region BussinessException
        /// <summary>
        /// 模块名称已存在
        /// </summary>
        private string ERROR_MODULE_EXIST
        {
            get { return "ERROR_MODULE_EXIST"; }
        }

        #endregion

        public int AddModule(Module module)
        {
            var checkModule = _moduleDao.GetModule(module.ModuleName);
            if (!checkModule.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_MODULE_EXIST);
            }
            return _moduleDao.AddModule(GetModulePoFromVo(module));
        }

        public void DeleteModule(int id)
        {
            _moduleDao.DeleteModule(id);
        }

        public void UpdateModule(Module module)
        {
            var checkModule = _moduleDao.GetModuleWithOutId(module.Id, module.ModuleName);
            if (!checkModule.IsNullOrEmpty())
            {
                throw new BussinessException(ERROR_MODULE_EXIST);
            }
            _moduleDao.UpdateModule(GetModulePoFromVo(module));
        }

        public Module GetModule(int id)
        {
            return GetModuleVoFromPo(_moduleDao.GetModule(id));
        }

        public IList<Module> GetModuleList(string orderStr)
        {
            return _moduleDao.GetModuleList(orderStr).Select(GetModuleVoFromPo).ToList();
        }

        #region 辅助方法

        Module GetModuleVoFromPo(ModulePo modulePo)
        {
            Module module = null;
            if (!modulePo.IsNullOrEmpty())
            {
                module = new Module
                    {
                        Id = modulePo.Id,
                        ModuleName = modulePo.ModuleName
                    };
            }
            return module;
        }

        ModulePo GetModulePoFromVo(Module module)
        {
            ModulePo modulePo = null;
            if (!module.IsNullOrEmpty())
            {
                modulePo = new ModulePo
                    {
                        Id = module.Id,
                        ModuleName = module.ModuleName
                    };
            }
            return modulePo;
        }

        #endregion
    }
}