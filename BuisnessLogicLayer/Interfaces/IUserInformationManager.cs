using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IUserInformationManager
    {
        public void UpdateUserShippingCredentials(int user_id, string address, string country, string postalCode, string city);
    }
}
