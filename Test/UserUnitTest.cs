using System;
using Autofac;
using HC.JiShi.UserRole.Model;
using HC.JiShi.UserRole.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            var user = new User()
            {
                Id = 4,
                UserName = "wangqitmtm",
                Password = "123456",
                CreateDate = DateTime.Now,
                IsAdmin = true,
                IsValid = true
            };
            var userService = Container.CommonContainer.Resolve<IUserService>();

            //userService.AddUser(user);

            //var users = userService.GetUserList();

            //userService.DeleteUser(2);

            //userService.DeleteUsers(new List<int> { 2, 7 });

            //userService.UpdateUser(user);

            //userService.UpdateUserName(4,"wangqtame");

            //userService.UpdatePassword(4, "123456", "1234567","1234567");

            //var userList = userService.GetUserList();

            PlayPlayDelegate aPlayPlayDelegate = () => Console.WriteLine("sb");

            Pram2Delegate aPram2Delegate = (s, s1) => Console.WriteLine("sbb");

            Pram2DelegateWithRe aPram2DelegateWithRe = (s, s1) => s + s1;

            Func<string, string, string> aFunc = (s, s1) => s + s1;
        }

        private delegate void PlayPlayDelegate();

        private delegate void Pram2Delegate(string a, string b);

        private delegate string Pram2DelegateWithRe(string a, string b);


    }
}
