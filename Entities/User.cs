using System;
using Entities.Enum;

namespace Entities
{
    public class User
    {
      
        public int id { private set; get; }

        public string Email { private set; get; }

        public string password { private set; get; }
        public string firstName { private set; get; }
        public string lastName { private set; get; }
        public string username { private set; get; }
        public DateTime creationDate { private set; get; }
        public AccountType AccountType { private set; get; }
        public string shipAddress { private set; get; }
        public string shipCity { private set; get; }
        public string shipPostalCode { private set; get; }

        public string shipCountry { private set; get; }

        public User(int id, string email, string password, string firstName, string lastName, string username, DateTime creationDate, AccountType accountType, string shipAddress, string shipCity, string shipPostalCode, string shipCountry)
        {
            this.id = id;
            this.Email = email;
            this.password = password;
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.creationDate = creationDate;
            this.AccountType= accountType;
            this.shipAddress = shipAddress;
            this.shipCity = shipCity;
            this.shipPostalCode = shipPostalCode;
            this.shipCountry = shipCountry;
        }
        public User(int id, string email, string firstName, string lastName, string username, DateTime creationDate, AccountType accountType, string shipAddress, string shipCity, string shipPostalCode, string shipCountry)
        {
            this.id = id;
            this.Email = email;
            
            this.firstName = firstName;
            this.lastName = lastName;
            this.username = username;
            this.creationDate = creationDate;
            this.AccountType = accountType;
            this.shipAddress = shipAddress;
            this.shipCity = shipCity;
            this.shipPostalCode = shipPostalCode;
            this.shipCountry = shipCountry;
        }
        public User(string username, string password, DateTime creationDate,string firstName, string lastName,string email, string shipAddress, string shipCity,string shipPostalCode,string shipCountry)
        {
            this.username=username;
            this.password=password;
            this.creationDate=creationDate;
            this.firstName=firstName;
            this.lastName=lastName;
            this.Email=email;
            this.shipAddress = shipAddress;
            this.shipCity = shipCity;
            this.shipPostalCode = shipPostalCode;
            this.shipCountry = shipCountry;
        }

    }
}
