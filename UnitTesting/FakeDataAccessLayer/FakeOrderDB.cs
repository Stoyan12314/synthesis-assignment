using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuisnessLogicLayer;
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
            orders.Add(order);
            return true;
                
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

        public List<OrderedItem> GetOrderedItems(int orderId)
        {
            foreach (Order order in orders)
            {
                if (order.OrderId == orderId)
                {
                    
                    return order.orderedItems;
                }
            }
            return null;
        }

        public List<Order> GetOrders(int limit)
        {
          
            return orders.Take(limit).ToList();
        }

        public List<Order> GetUsersOrders(int userId)
        {
            throw new NotImplementedException();
        }

        public bool ReturnOrderedItem(int itemId, int quantity, int orderId, string reason)
        {
            foreach (Order order in orders)
            {
                if (order.OrderId == orderId)
                {
                    foreach (var item in order.orderedItems)
                    {
                        if (item.item.id == itemId)
                        {
                            order.orderedItems.Remove(item);
                            return true;
                        }
                }
                }
               
            }
            return false;
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
