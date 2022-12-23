using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IOrderDetail
    {
        public List<OrderedItem> GetOrderedItems(int orderId);
    }
}
