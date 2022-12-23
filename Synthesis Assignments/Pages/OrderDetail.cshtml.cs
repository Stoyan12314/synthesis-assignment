using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Agreement;
using System.Collections.Generic;

namespace Synthesis_Assignments.Pages
{
    public class OrderDetailModel : PageModel
    {
        IOrderDetail IOrderDetail;
        public List<OrderedItem> items;
        public int orderId;
        public void OnGet(int orderId)
        {
            this.orderId = orderId;
            IOrderDetail = new OrderDetail(new DBOrder());
            items = IOrderDetail.GetOrderedItems(orderId);
        }
    }
}
