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
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Synthesis_Assignments.Pages
{
    public class checkoutPageModel : PageModel
    {
        
      
        [BindProperty] public CheckOut check { get; set; }
        [BindProperty] public List<OrderedItem> card { set; get; }
        private void LoadUserInformation()
        {
            IUserManager userManager = new UserManager(new DBUser());
            int id = Convert.ToInt32(User.FindFirst("userId").Value);
            User user = userManager.GetUser(id);
            check = new CheckOut();
            check.address = user.shipAddress;
            check.city = user.shipCity;
            check.country = user.shipCountry;
            check.postalCode = user.shipPostalCode;
        }
        public int LoadBonusPoints()
        {
            IBonusCard bonusCard = new BonusCardManager(new DBBonusCard());
            int userId = Convert.ToInt32(User.FindFirst("userId").Value);
            return  bonusCard.GetPointsFromCard(userId);
        }
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
            LoadUserInformation();
            return Page();
        }
       
        public ActionResult OnPostAsync()
        {
            this.card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            if (card != null)
            {
                IOrderManager orderManager = new OrderManager(new DBOrder());
                IBonusCard bonusCard = new BonusCardManager(new DBBonusCard());
                int userId = Convert.ToInt32(User.FindFirst("userId").Value);

                orderManager.CreateOrder(new Order(userId, card, DateTime.Now, DateTime.Today.AddDays(1), check.deliveryOption, DeliveryStatus.InProgress, check.address, check.city, check.postalCode, check.country));

                bonusCard.AddPointsToCard(userId, card.Sum(i => i.item.price * i.quantity));
                HttpContext.Session.Remove("card");
                return Page();

            }
            else 
            {
                ViewData["Message"] = string.Format("Shopping card is empty!");
                return Page();
            }

        }
       
        public ActionResult OnPostBonusPoints()
        {
            this.card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            if (card != null)
            {
                IOrderManager orderManager = new OrderManager(new DBOrder());
                IBonusCard bonusCard = new BonusCardManager(new DBBonusCard());
                int userId = Convert.ToInt32(User.FindFirst("userId").Value);




                double checkIfPossible = bonusCard.SpentPointsFromCard(userId, card.Sum(i => i.item.price * i.quantity));
                if (checkIfPossible == -1)
                {
                    ViewData["Message"] = string.Format("Not enough bonus points");
                }
                else
                {
                    orderManager.CreateOrder(new Order(userId, card, DateTime.Now, DateTime.Today.AddDays(1), check.deliveryOption, DeliveryStatus.InProgress, check.address, check.city, check.postalCode, check.country));
                    ViewData["Message"] = string.Format($"Total: {checkIfPossible}");
                    HttpContext.Session.Remove("card");
                }


                return Page();
            }
            else
            {
                ViewData["Message"] = string.Format("Shopping card is empty!");
                return Page();  
            }
           

        }

    }
}
