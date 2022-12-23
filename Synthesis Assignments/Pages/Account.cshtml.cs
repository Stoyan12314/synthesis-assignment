using DataAccessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using Entities.DTO;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using BuisnessLogicLayer;

namespace Synthesis_Assignments.Pages
{
    public class AccountModel : PageModel
    {
        [BindProperty] public CheckOut CheckOutDTO { get; set; }

        public User user { get; set; }
        public void OnGet()
        {
            IUserManager userManager = new UserManager(new DBUser());
           
            int userId = Convert.ToInt32(User.FindFirst("userId").Value);
            user = userManager.GetUser(userId);
            CheckOutDTO = new CheckOut();
            CheckOutDTO.address = user.shipAddress;
            CheckOutDTO.city = user.shipCity;
            CheckOutDTO.country = user.shipCountry;
            CheckOutDTO.postalCode = user.shipPostalCode;
            
        }
        public IActionResult OnPost()
        {
            int userId = Convert.ToInt32(User.FindFirst("userId").Value);

            IUserManager getUser = new UserManager(new DBUser());
            user = getUser.GetUser(userId);
            IUserInformationManager userInformationManager = new UserInformationManager(new DBUser());
            userInformationManager.UpdateUserShippingCredentials(user.id,CheckOutDTO.address, CheckOutDTO.country, CheckOutDTO.postalCode, CheckOutDTO.city);
            return Page();
        }
    }
}
