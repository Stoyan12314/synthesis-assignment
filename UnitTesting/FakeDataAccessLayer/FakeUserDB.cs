using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.Enum;
using DataAccessLayer;
using BuisnessLogicLayer;
using DataAccessLayer.Interfaces;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace UnitTesting.FakeDataAccessLayer
{
    public class FakeUserDB : IDBUser
    {
        List<User> users;
        public FakeUserDB(List<User> users)
        {
            this.users = users;
        }
        public User CheckLogin(string email)
        {
            foreach  (User user in users)
            {
                if (user.Email == email)
                {
                    return user;
                }

            }
            return null;
        }

        public bool CreateUser(string username, string password, DateTime creationDate, string firstName, string lastName, string email, string ship_address, string ship_city, string ship_postal_code, string ship_country)
        {
           
            users.Add(new User( username,  password, creationDate, firstName,  lastName,  email,  ship_address, ship_city, ship_postal_code,  ship_country));
            return true;

            
        }

        public string FindUserId(string username)
        {
            foreach (User user in users)
            {
                if (user.username == username)
                {
                    return user.id.ToString();
                }
            }
            return "";
        }

        public List<User> GetAllUsers()
        {
            return this.users;
        }

        public User GetUser(int id)
        {
            foreach  (User user in users)
            {
                if (user.id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public void UpdateUserShippingCredentials(int userId, string address, string country, string postalCode, string city)
        {
            foreach (var user in users.ToList())
            {
                if (userId == user.id)
                {
                    string userAddress = user.shipAddress;
                    string userCountry = user.shipCountry;
                    string userPostCode = user.shipPostalCode;
                    string userCity = user.shipCity;
                    users.Remove(user);
                    User u = new User(1, "abv.bg", "23OUNwT2vPC0qCHZEz74qaIQgsYBMCCsxhqm80JcBAv+bCVU", "Test", "Testov", "test123", DateTime.Now, AccountType.Customer, userAddress, userCity, userPostCode, userCountry);
                    users.Add(u);
                }
            }
        }
    }
}
