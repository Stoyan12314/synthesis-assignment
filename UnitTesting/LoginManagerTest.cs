using BuisnessLogicLayer;
using Entities.Enum;
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
    public class LoginManagerTest
    {

        [TestMethod]
        public void CheckLogin_LoginCheckedSuccesfully_Void()
        {
            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer, "s", "ss", "sss", "ssss");
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            LoginManager userManager = new LoginManager(fakeRepo);


            User check = userManager.CheckLogin("123", "abv.bg");

            Assert.IsTrue(users.Contains(user));
            Assert.IsNotNull(check);

        }
    }
}
