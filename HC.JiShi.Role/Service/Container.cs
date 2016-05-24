using Autofac;
using HC.JiShi.UserRole.ServiceImp;
using HC.JiShi.UserRole.ServiceImp.ModuleImp;
using HC.JiShi.UserRole.ServiceImp.PageActionImp;
using HC.JiShi.UserRole.ServiceImp.PageImp;
using HC.JiShi.UserRole.ServiceImp.PermissionImp;
using HC.JiShi.UserRole.ServiceImp.RoleImp;
using HC.JiShi.UserRole.ServiceImp.UserImp;
using HC.JiShi.UserRole.ServiceImp.UserRoleImp;

namespace HC.JiShi.UserRole.Service
{
    public class Container
    {
        public static IContainer CommonContainer { get; set; }

        private static readonly ContainerBuilder Builder = new ContainerBuilder();

        static Container()
        {
            RegisterUserDao();
            RegisterRoleDao();
            RegisterUserRoleDao();
            RegisterPageDao();
            RegisterPageActionDao();
            RegisterPermissionPageDao();
            RegisterPermissionPageActionDao();
            RegisterModuleDao();

            RegisterUserService();
            RegisterRoleService();
            RegisterPageService();
            RegisterPageActionService();
            RegisterPermissionService();
            RegisterModuleService();

            CommonContainer = Builder.Build();
        }

        #region Dao层注册

        private static void RegisterUserDao()
        {
            Builder.RegisterType<UserDao>().As<IUserDao>();
        }

        private static void RegisterRoleDao()
        {
            Builder.RegisterType<RoleDao>().As<IRoleDao>();
        }

        private static void RegisterUserRoleDao()
        {
            Builder.RegisterType<UserRoleDao>().As<IUserRoleDao>();
        }

        private static void RegisterPageDao()
        {
            Builder.RegisterType<PageDao>().As<IPageDao>();
        }

        private static void RegisterPageActionDao()
        {
            Builder.RegisterType<PageActionDao>().As<IPageActionDao>();
        }

        private static void RegisterPermissionPageDao()
        {
            Builder.RegisterType<PermissionPageDao>().As<IPermissionPageDao>();
        }

        private static void RegisterPermissionPageActionDao()
        {
            Builder.RegisterType<PermissionPageActionDao>().As<IPermissionPageActionDao>();
        }

        private static void RegisterModuleDao()
        {
            Builder.RegisterType<ModuleDao>().As<IModuleDao>();
        }
        #endregion

        #region Service注册

        private static void RegisterUserService()
        {
            Builder.RegisterType<UserService>().As<IUserService>();
        }

        private static void RegisterRoleService()
        {
            Builder.RegisterType<RoleService>().As<IRoleService>();
        }

        private static void RegisterPageService()
        {
            Builder.RegisterType<PageService>().As<IPageService>();
        }

        private static void RegisterPageActionService()
        {
            Builder.RegisterType<PageActionService>().As<IPageActionService>();
        }

        private static void RegisterPermissionService()
        {
            Builder.RegisterType<PermissionService>().As<IPermissionService>();
        }

        private static void RegisterModuleService()
        {
            Builder.RegisterType<ModuleService>().As<IModuleService>();
        }
        #endregion
    }
}