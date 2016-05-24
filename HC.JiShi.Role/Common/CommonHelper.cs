using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HC.JiShi.UserRole.Common
{
    /// <summary>
    /// 公共方法类-用于存放普通公用的方法
    /// </summary>
    public static class CommonHelper
    {
        #region 常用方法
        /// <summary>
        /// 判断对象是否为null,集合对象（包括数组）是否元素个数为0
        /// </summary>
        /// <typeparam name="T">任意对象数据类型</typeparam>
        /// <param name="data">要判断的数据</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this T data) where T : class
        {
            if (data == null)
            {
                return true;
            }

            if (data is string)
            {
                return string.IsNullOrEmpty(data as string);
            }

            if (data is ICollection)
            {
                return (data as ICollection).Count == 0;
            }

            return false;
        }
        #endregion
    }
}
