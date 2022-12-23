using System;
using System.Collections.Generic;
using System.Text;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IReturnItemManager
    {
		public bool ReturnOrderedItem(int itemId, int quantity, int orderId, string reason);
	}
}
