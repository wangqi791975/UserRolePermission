using System;

namespace HC.JiShi.UserRole.Model
{
    [Serializable]
    public class PageAction
    {
        public int Id { get; set; }

        public int PageId { get; set; }

        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionName { get; set; }

        /// <summary>
        /// 操作Url
        /// </summary>
        public string ActionUrl { get; set; }
    }
}