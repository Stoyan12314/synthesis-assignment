using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IRegisterManager
    {
        public bool Register(string username, string password, DateTime creationDate, string firstName, string lastName, string email, string ship_address, string ship_city, string ship_postal_code, string ship_country);

    }
}
