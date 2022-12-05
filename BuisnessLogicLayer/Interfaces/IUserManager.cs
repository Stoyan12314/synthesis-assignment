using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IUserManager
    {
        public string FindUserId(string username);
        public User CheckLogin(string password, string email);
        public void UpdateUsername(string username, string oldUsername);

        public void UpdatePassword(string username, string password);
        public bool Register(string username, string password, DateTime creationDate, string firstName, string lastName, string email);

        public List<User> GetAllUsers();


        public User GetUser(int id);
    }
}
