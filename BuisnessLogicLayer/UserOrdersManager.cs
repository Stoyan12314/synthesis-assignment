using BuisnessLogicLayer.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer;
using System.Linq;
using System.Threading.Tasks;

namespace BuisnessLogicLayer
{
    public class UserOrdersManager : IUserOrdersManager
    {
        private IDBOrder IDBOrder;
        public UserOrdersManager(IDBOrder IDBOrder)
        {
            this.IDBOrder = IDBOrder;
        }
        
        public List<Order> GetUsersOrders(int userId)
        {

           
          return IDBOrder.GetUsersOrders(userId);
        }
        public async Task<List<Order>> GetPaginatedResult(int userId, int currentPage, int pageSize = 10)
        {
          
            return IDBOrder.GetUsersOrders(userId).OrderBy(d => d.OrderId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<int> GetCount(int userId)
        {
            var data = IDBOrder.GetUsersOrders(userId);
            return data.Count;
        }
    }
}
