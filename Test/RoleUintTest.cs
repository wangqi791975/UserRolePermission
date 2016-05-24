using System;
using System.Collections.Generic;
using Autofac;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class RoleUintTest
    {
        private readonly IRoleService _roleService = Container.CommonContainer.Resolve<IRoleService>();

        [TestMethod]
        public void AddRoleTest()
        {
            var role = new Role
                {
                    RoleName = "营销111",
                    IsAdmin = false,
                    IsValid = true,
                    CreateDate = DateTime.Now
                };
            _roleService.AddRole(role);
        }

        [TestMethod]
        public void DeleteRoleTest()
        {
            _roleService.DeleteRole(2);
        }

        [TestMethod]
        public void DeleteRolesTest()
        {
            _roleService.DeleteRoles(new List<int> { 3, 4 });
        }

        [TestMethod]
        public void UpdateRoleTest()
        {
            var role = new Role
            {
                Id = 5,
                RoleName = "营销2",
                IsAdmin = false,
                IsValid = true,
                CreateDate = DateTime.Now
            };
            _roleService.UpdateRole(role);
        }

        [TestMethod]
        public void UpdateRoleIdNameTest()
        {
            _roleService.UpdateRole(5, "营销1");
        }

        [TestMethod]
        public void UpdateRoleIsAdminTest()
        {
            _roleService.UpdateRoleIsAdmin(5);
        }

        [TestMethod]
        public void UpdateRoleIsNotAdminTest()
        {
            _roleService.UpdateRoleIsNotAdmin(5);
        }

        [TestMethod]
        public void UpdateRolesIsAdminTest()
        {
            _roleService.UpdateRoleIsAdmin(new List<int> { 5, 6 });
        }

        [TestMethod]
        public void UpdateRolesIsNotAdminTest()
        {
            _roleService.UpdateRoleIsNotAdmin(new List<int> { 5, 6 });
        }

        [TestMethod]
        public void UpdateRoleIsValidTest()
        {
            _roleService.UpdateRoleIsValid(5);
        }

        [TestMethod]
        public void UpdateRoleIsNotValidTest()
        {
            _roleService.UpdateRoleIsNotValid(5);
        }

        [TestMethod]
        public void UpdateRolesIsValidTest()
        {
            _roleService.UpdateRoleIsValid(new List<int> { 5, 6 });
        }

        [TestMethod]
        public void UpdateRolesIsNotValidTest()
        {
            _roleService.UpdateRoleIsNotValid(new List<int> { 5, 6 });
        }

        [TestMethod]
        public void GetRoleByIdTest()
        {
            var role = _roleService.GetRole(5);
        }

      
    }
}