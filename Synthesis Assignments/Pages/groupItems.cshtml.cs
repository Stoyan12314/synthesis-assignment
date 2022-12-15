using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BuisnessLogicLayer;
using DataAccessLayer;
using Entities;
using DataAccessLayer.Interfaces;
using BuisnessLogicLayer.Interfaces;
using System.Collections.Generic;

namespace Synthesis_Assignments.Pages
{
    public class groupItemsModel : PageModel
    {
        public IItemManager itemManager = new ItemManager(new DBItem());
        public List<Item> items;
        public void OnGet(string category)
        {
            items = itemManager.GetItemWithCategory(category);
        }
    }
}
