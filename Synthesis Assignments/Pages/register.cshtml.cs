using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities.DTO;
using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer;
using DataAccessLayer;
using Microsoft.Win32;
using System;

namespace Synthesis_Assignments.Pages
{
    public class registerModel : PageModel
    {
        [BindProperty] public Register Register { get; set; }
        private IUserManager userManager = new UserManager(new DBUser());
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                   
                        bool registrationSucessful = userManager.Register(Register.username, Register.username, DateTime.Now, Register.firstName, Register.lastName, Register.email);
                        if (registrationSucessful)
                        {
                            return new RedirectToPageResult("/Privacy");
                        }
                        else
                        {
                            return Page();
                        }
                }
                catch (Exception ex)
                {
                    return new RedirectToPageResult("Error");
                }
            }
            else
            {
                return Page();
            }
        }
    }
}
