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
    public class UserInformationManagerTest
    {
        [TestMethod]
        public void ChangeUserLocation_UserLocationChangedSuccesfully_Void()
        {

            User user = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer, "s", "ss", "sss", "ssss");
            List<User> users = new List<User>();
            users.Add(user);


            FakeUserDB fakeRepo = new FakeUserDB(users);

            UserInformationManager userManager = new UserInformationManager(fakeRepo);


            userManager.UpdateUserShippingCredentials(1,"1","1","1","1");


            //beause the user is different in the method u!=user
            Assert.IsFalse(users.Contains(user)); 
            Assert.AreNotEqual(user.shipCountry,"s");

        }
    }
}
