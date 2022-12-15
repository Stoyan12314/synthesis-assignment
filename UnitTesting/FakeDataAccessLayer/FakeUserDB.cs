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

        public bool CreateUser(string username, string password, DateTime creationDate, string firstName, string lastName, string email)
        {
            foreach (User user in users)
            {
                if (user.Email == email)
                {
                    return false;
                }
                else
                {
                    users.Add(new User(username, password, creationDate, firstName, lastName, email, AccountType.Customer));
                        return true;
                }

            }
            return false;
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

       
       
    }
}
