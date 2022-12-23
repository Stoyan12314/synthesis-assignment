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
        private IRegisterManager registerManager = new RegisterManager(new DBUser());
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                        
                        bool registrationSucessful = registerManager.Register(Register.username, Register.password, DateTime.Now, Register.firstName, Register.lastName, Register.email, Register.shipAddress, Register.shipCity, Register.shipPostalCode, Register.shipCountry);
                        if (registrationSucessful)
                        {
                            return new RedirectToPageResult("/index");
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
