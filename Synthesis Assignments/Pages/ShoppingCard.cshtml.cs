using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer;



namespace Synthesis_Assignments.Pages
{
    public class ShoppingCardModel : PageModel
    {

        public List<OrderedItem> card { get; set; }
        public double Total { get; set; }

        public void OnGet()
        {
            card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            Total = card.Sum(i => i.item.price * i.quantity);
        }

        public IActionResult OnGetBuyNow(int id)
        {
            IItemManager itemManager = new ItemManager(new DBItem());
            Item item = itemManager.GetItemWith(id);
            card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            if (card == null)
            {
                card = new List<OrderedItem>();
                card.Add(new OrderedItem(item, 1));
              
                SessionHelper.SetObjectAsJson(HttpContext.Session, "card", card);
            }
            else
            {
                int index = Exists(card, id);
                if (index == -1)
                {
                    card.Add(new OrderedItem(item, 1));
                   
                }
                else
                {
                    card[index].quantity++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "card", card);
            }
            return RedirectToPage("ShoppingCard");
        }

        public IActionResult OnGetDelete(int id)
        {
            card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            int index = Exists(card, id);
            card.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "card", card);
            return RedirectToPage("ShoppingCard");
        }

        public IActionResult OnPostUpdate(int[] quantities)
        {
            card = SessionHelper.GetObjectFromJson<List<OrderedItem>>(HttpContext.Session, "card");
            for (var i = 0; i < card.Count; i++)
            {
                card[i].quantity = quantities[i];
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "card", card);
            return RedirectToPage("ShoppingCard");
        }

        private int Exists(List<OrderedItem> cart, int id)
        {
            for (var i = 0; i < cart.Count; i++)
            {
                if (cart[i].item.id == id)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
