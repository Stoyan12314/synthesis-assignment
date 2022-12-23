using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using Entities.Enum;

namespace Entities.DTO
{
    public class CheckOut
    {
        [Required][DisplayName("Email")] public string email { get; set; }
        [Required][DisplayName("Delivery option")] public DeliveryOption deliveryOption { get; set; }

        [Required][DisplayName("address")] public string address { get; set; }
      
        [Required][DisplayName("city")] public string city { get; set; }
        [Required][DataType(DataType.PostalCode)][DisplayName("postal code")] public string postalCode { get; set; }

        [Required][DisplayName("country")] public string country { get; set; }


    }
}
