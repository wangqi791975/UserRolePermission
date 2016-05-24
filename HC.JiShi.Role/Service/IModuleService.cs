using System.Collections.Generic;
using HC.JiShi.UserRole.Model;

namespace HC.JiShi.UserRole.Service
{
    public interface IModuleService
    {
        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        int AddModule(Module module);

        /// <summary>
        /// 删除模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void DeleteModule(int id);

        /// <summary>
        /// 修改模块
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        void UpdateModule(Module module);

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Module GetModule(int id);

        /// <summary>
        /// 获取所有模块
        /// </summary>
        /// <returns></returns>
        IList<Module> GetModuleList(string orderStr);
    }
}