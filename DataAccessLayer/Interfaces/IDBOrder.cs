using Entities;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IDBOrder
    {
        public bool CreateOrder(Order order);
        public List<Order> GetOrders(int limit);
        public Order GetOrder(int id);
        public void UpgradeOrder(DeliveryStatus status, int orderId);
        public void AddOrderDetail(Order order, int orderId);
    }
}
