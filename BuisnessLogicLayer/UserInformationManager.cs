using System;
using System.Collections.Generic;
using System.Text;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
namespace BuisnessLogicLayer
{
    public class UserInformationManager : IUserInformationManager
    {
        IDBUser IDBUser;
        public UserInformationManager(IDBUser IDBUser)
        {
            this.IDBUser = IDBUser;
        }
        public void UpdateUserShippingCredentials(int userId, string address, string country, string postalCode, string city)
        {
            IDBUser.UpdateUserShippingCredentials(userId, address, country, postalCode, city);
        }
    }
}
