using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BuisnessLogicLayer.Interfaces;

namespace BuisnessLogicLayer
{
    public class OrderDetail : IOrderDetail
    {
        private IDBOrder IDBOrder;
        public OrderDetail(IDBOrder IDBOrder)
        {
            this.IDBOrder = IDBOrder;
        }
        public List<OrderedItem> GetOrderedItems(int orderId)
        {
           return IDBOrder.GetOrderedItems(orderId);
        }
    }
}
