using System;
using System.Collections.Generic;
using System.Text;
using BuisnessLogicLayer;
using Entities.Enum;

namespace Entities
{
    public class Order
    {
        private List<OrderedItem> orderedItems= new List<OrderedItem>();
        private int OrderId;
        private OrderedItem orderedItem;
        private DateTime OrderDate;
        private DateTime DeliveryDate;
        private DeliveryOption DeliveryOption;
        private DeliveryStatus DeliveryStatus;

        public Order() //ctor for creation without id 
        {
                
        }
        //public Order() //ctor for creation with id
        //{

        //}
        public void CreateOrder()
        {
            
        }
      
    }
}
