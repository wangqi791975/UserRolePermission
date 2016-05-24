using System;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class Page
    {
        public int Id { get; set; }

        public int ModuleId { get; set; }

        /// <summary>
        /// 页面名称
        /// </summary>
        public string PageName { get; set; }

        public string Url { get; set; }
        
        /// <summary>
        /// 域名
        /// </summary>
        public string Domain { get; set; }
    }
}