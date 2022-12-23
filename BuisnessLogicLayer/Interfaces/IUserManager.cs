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
        public User GetUser(int id);
    }
}
