using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using BuisnessLogicLayer;
using BuisnessLogicLayer.Interfaces;

namespace Synthesis_Assignments.Pages
{
    public class HomeModel : PageModel
    {
        public IItemManager itemManager { get; set; } 
        public ICategoryManager categoryManager { get; set; }
       // public ICategoryManager categoryManager { get; set; }
        public HomeModel()
        {
            itemManager = new ItemManager(new DBItem());
            categoryManager = new CategoryManager(new DBCategory());
        }
    }
}
