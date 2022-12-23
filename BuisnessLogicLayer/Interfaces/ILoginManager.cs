using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface ILoginManager
    {
        public User CheckLogin(string password, string email);
    }
}
