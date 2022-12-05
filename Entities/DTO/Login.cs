using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DTO
{
    public class Login
    {
        [Required][DisplayName("Email")] public string email { get; set; }
        [Required][DataType(DataType.Password)][DisplayName("Password")] public string password { get; set; }
    }
}
