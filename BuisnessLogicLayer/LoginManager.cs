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
    public class LoginManager : ILoginManager
    {
        private IDBUser IDBUser;
        public LoginManager(IDBUser IDBUser)
        {
            this.IDBUser = IDBUser;
        }
        public User CheckLogin(string password, string email)
        {
            
            User user = IDBUser.CheckLogin(email);
            if (user == null)
            {
                return null;
            }
            string hashedPass = user.password;
            bool checkVal = PasswordHash.Validate(password, hashedPass);
            if (checkVal is true)
            {
                return user;
            }
            return null;
        }

    }
}
