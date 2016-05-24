namespace HC.JiShi.UserRole.Common
{
    public class CacheKey
    {
        /// <summary>
        /// 用户拥有权限页面（list<string/>）
        /// </summary>
        public static string KeyUserPageUrl { get { return "KeyUserPageUrl"; } }

        /// <summary>
        /// 用户拥有权限页面
        /// </summary>
        public static string KeyUserPermissionPage { get { return "UserPermissionPage"; } }

        /// <summary>
        /// 所有页面
        /// </summary>
        public static string KeyAllPage { get { return "KeyAllPage"; } }

        /// <summary>
        /// 左侧导航栏
        /// </summary>
        public static string KeyModulePages { get { return "KeyModulePages"; } }
    }
}