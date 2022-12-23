using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IUserOrdersManager
    {
        public List<Order> GetUsersOrders(int userId);
        public Task<List<Order>> GetPaginatedResult(int userId, int currentPage, int pageSize = 10);
        public Task<int> GetCount(int userId);
    }
}
