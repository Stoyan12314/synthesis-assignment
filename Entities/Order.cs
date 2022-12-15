using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using BuisnessLogicLayer;
using Entities.Enum;

namespace Entities
{
    public class Order
    {
        public List<OrderedItem> orderedItems { get; set; }
        public int userId { get; set; }
        public int OrderId { get; set; }
        public OrderedItem orderedItem { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DeliveryOption DeliveryOption { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }

        public string shipAddress { get; set; } 

        public string shipCity { get; set; }    

        public string shipPostCode { get; set; }
        public string shipCountry { get; set; }

        public Order(int user_id, List<OrderedItem> orderedItems, DateTime OrderDate, DateTime DeliveryDate, DeliveryOption DeliveryOption, DeliveryStatus DeliveryStatus, string shipAddress,string shipCity, string shipPostCode, string shipCountry) 
        {
            this.orderedItems = new List<OrderedItem>();
            this.userId = user_id;
            this.orderedItems = orderedItems;
            this.OrderDate = OrderDate;
            this.DeliveryDate = DeliveryDate;
            this.DeliveryOption = DeliveryOption;
            this.DeliveryStatus = DeliveryStatus;
            this.shipAddress= shipAddress;
            this.shipCity= shipCity;
            this.shipPostCode= shipPostCode;
            this.shipCountry = shipCountry;
            
        }
        public Order(int orderId, int user_id, DateTime OrderDate, DateTime DeliveryDate, DeliveryOption DeliveryOption, DeliveryStatus DeliveryStatus, string shipAddress, string shipCity, string shipPostCode, string shipCountry)
        {
            this.userId = user_id;
            this.OrderId = orderId;
            this.orderedItems = orderedItems;
            this.DeliveryDate = DeliveryDate;
            this.DeliveryOption = DeliveryOption;
            this.DeliveryStatus = DeliveryStatus;
            this.shipAddress= shipAddress;
            this.shipCity= shipCity;
            this.shipPostCode= shipPostCode;
            this.shipCountry= shipCountry;
            this.OrderDate= OrderDate;
            this.shipCity = shipCity;
        }
        //public Order() //ctor for creation with userId
        //{

        //}


    }
}
