using System.Collections.Generic;
using Autofac;
using HC.JiShi.UserRole.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class PermissionUnitTest
    {
        private readonly IPermissionService _permissionService = Container.CommonContainer.Resolve<IPermissionService>();
        [TestMethod]
        public void BindUserPermissionPageTest()
        {
            _permissionService.BindUserPermissionPage(1, 4);
        }

        [TestMethod]
        public void BindUserPermissionPagesTest()
        {
            _permissionService.BindUserPermissionPage(1, new List<int> { 1, 2, 3 });
        }

        [TestMethod]
        public void BindUserPermissionPageActionTest()
        {
            _permissionService.BindUserPermissionPageAction(1, 13);
        }

        [TestMethod]
        public void BindUserPermissionPageActionsTest()
        {
            _permissionService.BindUserPermissionPageAction(1, new List<int> { 11, 12, 14 });
        }

        [TestMethod]
        public void GetUserPermissionPage()
        {
            var a = _permissionService.GetUserPermissionPage(4);
        }

        [TestMethod]
        public void GetUserPermissionsPage()
        {
            var a = _permissionService.GetUserPermissionPage();
        }
    }
}