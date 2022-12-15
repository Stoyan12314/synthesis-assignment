using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer;
using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace Synthesis_Assignments.Pages
{
    public class groupSubItemsModel : PageModel
    {

        public IItemManager itemManager = new ItemManager(new DBItem());
        public List<Item> items;
        public void OnGet(string SubCategory)
        {
            items = itemManager.GetItemWithSubCategory(SubCategory);
        }
      
    }
}
