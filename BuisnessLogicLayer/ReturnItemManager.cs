using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer;

namespace BuisnessLogicLayer
{
	public class ReturnItemManager : IReturnItemManager
	{
		private IDBOrder returnItemManager;
		private IOrderManager orderManager;
		private IItemManager itemManager;

        public ReturnItemManager(IDBOrder returnItemManager)
		{
			this.returnItemManager = returnItemManager;
		}
        public bool ReturnOrderedItem(int itemId, int quantity, int orderId, string reason)
        {
			itemManager = new ItemManager(new DBItem());
			orderManager = new OrderManager(new DBOrder());
            Item item = itemManager.GetItemWith(itemId);
            Order order = orderManager.GetOrder(orderId);
            int todayDate = DateTime.Now.Day;
            int orderDate = order.DeliveryDate.Day;
            if (item.category.category.Contains("goods"))
			{
				
				if (todayDate - orderDate <= 14)
				{
					return returnItemManager.ReturnOrderedItem(itemId, quantity, orderId, reason);
				}
				else
				{
					return false;
				}
			}
			else
			{
               
				if (todayDate - orderDate > 1)
				{
					return false;
				}
				else 
				{
                    return returnItemManager.ReturnOrderedItem(itemId, quantity, orderId, reason);
                }
            }
			
        }
	}
}
