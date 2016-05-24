//*******************************
//公司：五金集市
//功能：微软自带的缓存操作底层
//时间：2014年07月08日
//作者：redarmy
//*******************************

using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
namespace HC.Jishi.UserRole.Common
{
    public class DataCache
    {
        private const int Interval = 60;
        private static readonly Cache MCache;

        static DataCache()
        {
            var current = HttpContext.Current;
            MCache = current != null ? current.Cache : HttpRuntime.Cache;
        }

        public static void Clear()
        {
            var enumerator = MCache.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MCache.Remove(enumerator.Key.ToString());
            }
        }

        public static object Get(string key)
        {
            return MCache[key];
        }

        public static T Get<T>(string key)
        {
            return (T)MCache[key];
        }

        public static void Insert(string key, object obj)
        {
            Insert(key, obj, null, Interval);
        }

        public static void Insert(string key, object obj, int minutes)
        {
            Insert(key, obj, null, minutes);
        }

        public static void Insert(string key, object obj, CacheDependency dep)
        {
            Insert(key, obj, dep, Interval);
        }

        public static void Insert(string key, object obj, int minutes, CacheItemPriority priority)
        {
            Insert(key, obj, null, minutes, priority);
        }

        public static void Insert(string key, object obj, CacheDependency dep, int minutes)
        {
            Insert(key, obj, dep, minutes, CacheItemPriority.Normal);
        }

        public static void Insert(string key, object obj, CacheDependency dep, int minutes, CacheItemPriority priority)
        {
            if (obj != null)
            {
                MCache.Insert(key, obj, dep, DateTime.Now.AddMinutes(minutes), TimeSpan.Zero, priority, null);
            }
        }

        public static void Remove(string key)
        {
            Remove(key, false);
        }

        public static void Remove(string key, bool isPatternRegex)
        {
            if (isPatternRegex)
            {
                var enumerator = MCache.GetEnumerator();
                var regex = new Regex(key, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
                while (enumerator.MoveNext())
                {
                    if (regex.IsMatch(enumerator.Key.ToString()))
                    {
                        MCache.Remove(enumerator.Key.ToString());
                    }
                }
            }
            else
            {
                MCache.Remove(key);
            }
        }
    }
}
