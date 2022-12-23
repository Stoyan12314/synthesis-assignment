using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Synthesis_Assignments.Pages
{
    public class OrderHistoryModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));


    

        IUserOrdersManager UserOrdersManager;
        public List<Order> orders { get; set; }

        
        public async Task OnGetAsync()
        {
                UserOrdersManager = new UserOrdersManager(new DBOrder());
                orders = await UserOrdersManager.GetPaginatedResult(Convert.ToInt32(User.FindFirst("userId").Value), CurrentPage, PageSize);
                Count = await UserOrdersManager.GetCount(Convert.ToInt32(User.FindFirst("userId").Value));
        }
       
    }
}
