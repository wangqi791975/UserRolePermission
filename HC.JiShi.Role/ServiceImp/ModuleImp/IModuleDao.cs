using System.Collections.Generic;
using HC.JiShi.UserRole.Entity;

namespace HC.JiShi.UserRole.ServiceImp.ModuleImp
{
    public interface IModuleDao
    {
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="modulePo"></param>
        /// <returns></returns>
        int AddModule(ModulePo modulePo);

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteModule(int id);

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="modulePo"></param>
        void UpdateModule(ModulePo modulePo);

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ModulePo GetModule(int id);

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        IList<ModulePo> GetModuleList(string orderStr);

        /// <summary>
        /// 通过模块名称获取模块
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ModulePo GetModule(string name);

        /// <summary>
        /// 通过模块名称获取模块（不包含Id）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        ModulePo GetModuleWithOutId(int id, string name);
    }
}