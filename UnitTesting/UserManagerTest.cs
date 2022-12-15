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
    public class UserManagerTest
    {

        [TestMethod]
        public void CheckLogin_LoginCheckedSuccesfully_Void()
        {
            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test","Testov", "test123", DateTime.Now, AccountType.Customer);
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            UserManager userManager = new UserManager(fakeRepo);


            User check = userManager.CheckLogin("123","abv.bg");


            Assert.IsNotNull(check);

        }

        [TestMethod]
        public void CreateUser_LoginCheckedSuccesfully_Void()
        {
            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer);
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            UserManager userManager = new UserManager(fakeRepo);


           bool check=  userManager.Register("test123", "123", DateTime.Now, "Test", "Testov", "abv.bg");


            Assert.IsFalse(check);

        }

        [TestMethod]
        public void FindUserId_UserFoundSuccesfully_Void()
        {
            
            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer);
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            UserManager userManager = new UserManager(fakeRepo);


            string check = userManager.FindUserId("test123");


            Assert.AreEqual("1", check);

        }

        [TestMethod]
        public void GetAllUsers_UsersGottenSuccesfully_Void()
        {

            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer);
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            UserManager userManager = new UserManager(fakeRepo);


            List<User> gottenUser = userManager.GetAllUsers();


            Assert.AreEqual(users[0].id, gottenUser[0].id);

        }


        [TestMethod]
        public void GetUser_UserGottenSuccesfully_Void()
        {

            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer);
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            UserManager userManager = new UserManager(fakeRepo);


            User gottenUser = userManager.GetUser(1);


            Assert.AreEqual(gottenUser.id, user.id);

        }

       
  
    }


}
