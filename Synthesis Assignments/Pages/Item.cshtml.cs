using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Agreement;
using System;
using Entities;
namespace Synthesis_Assignments.Pages
{

    public class ItemModel : PageModel
    {
        public IItemManager itemManager = new ItemManager(new DBItem());
        int item_id;
        public  Item item;
        public IActionResult OnGet(int id)
        {
            try
            {
                this.item_id = id;
                item = itemManager.GetItemWith(item_id);
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public void OnPost() 
        {
        
        }
    }
}
