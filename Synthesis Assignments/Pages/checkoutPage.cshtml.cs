using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Entities;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Entities.DTO;
using System;
using Entities.Enum;

namespace Synthesis_Assignments.Pages
{
    public class checkoutPageModel : PageModel
    {
        IOrderManager orderManager;
        [BindProperty] public CheckOut check { get; set; }
        [BindProperty] public List<OrderedItem> card { set; get; }
        public IActionResult OnGet()
        {
            this.card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            foreach (var item in this.card)
            {
                if (item.quantity == 0)
                {
                    return RedirectToPage("/Home");
                }
            }
          
            
            return Page();
        }
       
        public ActionResult OnPostAsync()
        {
            this.card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            IOrderManager orderManager = new OrderManager(new DBOrder());
            int user_id = Convert.ToInt32(User.FindFirst("userId").Value);
            orderManager.CreateOrder(new Order(user_id,card, DateTime.Now, DateTime.Today.AddDays(1), check.deliveryOption, DeliveryStatus.InProgress, check.address, check.city, check.postalCode, check.country));

            return Page();
           
        }
    }
}
