using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Synthesis_Assignments.Pages
{
    public class ReturnItemModel : PageModel
    {
        IReturnItemManager returnItemManager;
        int itemId;
        int orderId;
        int quantity;
        public void OnGet(int itemId, int quantity, int orderId)
        {
          
          this.itemId = itemId;
          this.orderId = orderId;
           this.quantity = quantity;


		}
	
		public IActionResult OnPost() 
        {
            returnItemManager = new ReturnItemManager(new DBOrder());
            string reason = Request.Form["reason"];
            int itemId = Convert.ToInt32(PageContext.HttpContext.Request.Query["itemId"]);
            int quantity = Convert.ToInt32(PageContext.HttpContext.Request.Query["quantity"]);
            int orderId = Convert.ToInt32(PageContext.HttpContext.Request.Query["orderId"]);
          
            returnItemManager.ReturnOrderedItem(itemId, quantity, orderId, reason);
            return new RedirectToPageResult("/OrderHistory");
           
        }

    }
}
