using System;
using System.Collections.Generic;
using System.Text;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities;
using Entities.Enum;

namespace BuisnessLogicLayer
{
    public class OrderManager : IOrderManager
    {
        private IDBOrder DBOrder;


        public OrderManager(IDBOrder DBOrder)
        {

            this.DBOrder = DBOrder;
        }

        public bool CreateOrder(Order order)
        {
            return DBOrder.CreateOrder(order);
        }
        public List<Order> GetOrders(int limit)
        {
            return DBOrder.GetOrders(limit);
        }
        public Order GetOrder(int id)
        {
            return DBOrder.GetOrder(id);
        }
        public void UpgradeOrder(DeliveryStatus status, int order_id)
        {
            DBOrder.UpgradeOrder(status, order_id);
        }
      

    }
}
