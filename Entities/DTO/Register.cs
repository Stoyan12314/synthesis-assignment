using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace Entities.DTO
{
    public class Register
    {
        [Required][DisplayName("Email")] public string email { get; set; }
        [Required][DataType(DataType.Password)][DisplayName("Password")] public string password { get; set; }

        [Compare(nameof(password), ErrorMessage = "Password doesn't match!"), Required][DataType(DataType.Password)][DisplayName("Password")] public string RepPassword { get; set; }
       
        [Required][DisplayName("Username")] public string username { get; set; }
        [Required][DisplayName("First Name")] public string firstName { get; set; }
        [Required][DisplayName("Last Name")] public string lastName { get; set; }
        [Required][DisplayName("Address")] public string shipAddress { get; set; }

        [Required][DisplayName("City")] public string shipCity { get; set; }
        [Required][DisplayName("Postal code")] public string shipPostalCode { get; set; }

        [Required][DisplayName("Country")] public string shipCountry { get; set; }

    }
}
