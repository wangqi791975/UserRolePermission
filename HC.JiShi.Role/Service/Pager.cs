using System;

namespace HC.JiShi.UserRole.Service
{
    /// <summary>
    /// 查询分页类
    /// </summary>
    [Serializable]
    public sealed class Pager
    {
        /// <summary>
        /// 获取当前页码
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 获取分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 获取总分页数
        /// </summary>
        public int PageCount { get; protected set; }

        /// <summary>
        /// 获取当前页起始行号
        /// </summary>
        public int StartRowNumber { get; protected set; }

        /// <summary>
        /// 获取当前页截止行号
        /// </summary>
        public int EndRowNumber { get; protected set; }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        public int TotalRowCount { get; protected set; }

        /**
         * 构造函数
         */
        public Pager()
        {

        }

        /**
         * 构造函数
         * @param totalRowCount 总记录数
         * @param currentPage 当前页码
         * @param pageSize 分页大小
         */

        public Pager(int totalRowCount, int currentPage, int pageSize)
        {
            TotalRowCount = totalRowCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Init();
        }

        /**
         * 初始化函数
         */
        private void Init()
        {
            if (TotalRowCount < 0 || CurrentPage < 1 || PageSize < 1)
            {
                throw new Exception("illegal arguments totalRowCount:" + TotalRowCount + ", currentPage:" + CurrentPage + ", pageSize:" + PageSize);
            }

            PageCount = ((TotalRowCount % PageSize) == 0 ? (TotalRowCount / PageSize) : (TotalRowCount / PageSize) + 1);
            
            // 如果没有数据，设为第1页
            if (PageCount == 0)
            { 
                PageCount = 1;
            }
            
            // 超过最后一页, 取最后一页
            if (CurrentPage > PageCount)
            {
                CurrentPage = PageCount; 
            }
            StartRowNumber = (CurrentPage - 1) * PageSize + 1;
            EndRowNumber = CurrentPage * PageSize > TotalRowCount ? TotalRowCount : CurrentPage * PageSize;
        }

        
    }
}
