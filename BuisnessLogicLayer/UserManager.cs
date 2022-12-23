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


        public User GetUser(int id)
        {
            return DBUser.GetUser(id);
        }



    }
}
