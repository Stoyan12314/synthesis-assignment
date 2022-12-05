using System;
using Entities;
using BuisnessLogicLayer;
using DataAccessLayer;
using System.Collections.Generic;
using Entities;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;

namespace BuisnessLogicLayer
{
    public class UserManager : IUserManager 
    {
        private IDBUser DBUser;
        public UserManager(IDBUser DBUser)
        {
            this.DBUser = DBUser;
        }
        public string FindUserId(string username)
        {
            return DBUser.FindUserId(username);
        }
        public User CheckLogin(string password, string email)
        {
         
            User user = DBUser.CheckLogin(email);
            if(user == null)
            {
                return null;
            }
            bool checkVal = PasswordHash.Validate(password, user.password);
            if (checkVal is true)
            {
                return user;
            }
            return null;
        }


        public void UpdateUsername(string username, string oldUsername)
        {
            DBUser.UpdateUsername(username, oldUsername);

        }
        public void UpdatePassword(string username, string password)
        {
            DBUser.UpdatePassword(username, PasswordHash.Hash(password));
        }
        public bool Register(string username, string password, DateTime creationDate, string firstName, string lastName, string email)
        {
            
            if (DBUser.CheckLogin(email) == null)
            {
                password = PasswordHash.Hash(password);
                DBUser.CreateUser(username,  password,  creationDate,  firstName,  lastName,  email);
                return true;
            }
            return false;

        }
        public List<User> GetAllUsers()
        {
            return DBUser.GetAllUsers();
        }


        public User GetUser(int id)
        {
            return DBUser.GetUser(id);
        }



    }
}
