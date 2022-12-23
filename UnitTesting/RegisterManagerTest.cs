using BuisnessLogicLayer;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTesting.FakeDataAccessLayer;

namespace UnitTesting
{
    [TestClass]
    class RegisterManagerTest
    {
        [TestMethod]
        public void CreateUser_LoginCheckedSuccesfully_Void()
        {
            User user = new User("test123", "123", DateTime.Now, "Test", "Testov", "abv.bg", "s", "ss", "sss", "ssss");
            List<User> users = new List<User>();


            FakeUserDB fakeRepo = new FakeUserDB(users);

            RegisterManager userManager = new RegisterManager(fakeRepo);


            bool check = userManager.Register("test123", "123", DateTime.Now, "Test", "Testov", "abv.bg", "s", "ss", "sss", "ssss");

            Assert.IsTrue(users.Contains(user));
            Assert.IsTrue(check);

        }

    }
}
