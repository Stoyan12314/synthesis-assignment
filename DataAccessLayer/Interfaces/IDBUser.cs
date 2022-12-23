using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
namespace DataAccessLayer.Interfaces
{
    public interface IDBUser
    {

        public bool CreateUser(string username, string password, DateTime creationDate, string firstName, string lastName, string email, string ship_address, string ship_city, string ship_postal_code, string ship_country);

        public void UpdateUserShippingCredentials(int userId, string address, string country, string postalCode, string city);
        public User GetUser(int id);

        public User CheckLogin(string email);
        public string FindUserId(string username);
      
    }
}
