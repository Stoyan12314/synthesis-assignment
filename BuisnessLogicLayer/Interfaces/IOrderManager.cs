using Entities;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IOrderManager
    {
        public bool CreateOrder(Order order);
        public List<Order> GetOrders(int limit);
        public Order GetOrder(int id);
        public void UpgradeOrder(DeliveryStatus status, int orderId);
    }
}
