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
    public class RegisterManager : IRegisterManager
    {
        private IDBUser IDBuser;
        public RegisterManager(IDBUser IDBuser)
        {
            this.IDBuser = IDBuser;
        }
        public bool Register(string username, string password, DateTime creationDate, string firstName, string lastName, string email, string ship_address, string ship_city, string ship_postal_code, string ship_country)
        {

            if (IDBuser.CheckLogin(email) == null)
            {
                password = PasswordHash.Hash(password);
                IDBuser.CreateUser(username, password, creationDate, firstName, lastName, email, ship_address, ship_city, ship_postal_code, ship_country);
                return true;
            }
            return false;

        }
    }
}
