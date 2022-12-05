using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IDBUser
    {

        public bool CreateUser(string username, string password, DateTime creationDate, string firstName, string lastName, string email);


        public User GetUser(int id);

        public List<User> GetAllUsers();

        public User CheckLogin(string email);
        public string FindUserId(string username);
        public void UpdateUsername(string username, string oldUsername);
        public void UpdatePassword(string username, string password);
    }
}
