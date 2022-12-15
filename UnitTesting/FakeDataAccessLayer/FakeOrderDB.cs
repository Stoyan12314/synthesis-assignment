using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enum;
using Org.BouncyCastle.Utilities;

namespace UnitTesting.FakeDataAccessLayer
{
    public class FakeOrderDB : IDBOrder
    {
        List<Order> orders;
        public FakeOrderDB(List<Order> orders)
        {
            this.orders = orders;
        }
        public bool CreateOrder(Order order)
        {
            foreach (Order g in orders)
            {
                if (g.OrderId != order.OrderId)
                {
                    orders.Add(order);
                    return true;
                }
            }
            return false;
        }

        public Order GetOrder(int id)
        {
            foreach (Order g in orders)
            {
                if (g.userId == id)
                {
                   
                    return g;
                }
            }
            return null;
        }

        public List<Order> GetOrders(int limit)
        {
          
            return orders.Take(limit).ToList();
           
        }

        public void UpgradeOrder(DeliveryStatus status, int order_id)
        {
            foreach (Order g in orders)
            {
                if (g.OrderId == order_id)
                {
                    g.DeliveryStatus = status;
                  
                }
            }
           
        }
    }
}
