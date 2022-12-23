using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTO;
using Entities;

using System.Security.Claims;
using DataAccessLayer;
using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer;
using Microsoft.AspNetCore.Authorization;

namespace Synthesis_Assignments.Pages
{
	
	[AllowAnonymous]
	public class IndexModel : PageModel
    {
        [BindProperty] public Login Login { get; set; }
      

        public IndexModel()
        {

        }

        public void OnGet()
        {

        }
        public async void Auth(string user)
        {
            IUserManager userManager = new UserManager(new DBUser());
            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(28)
            };
           
            var claims = new List<Claim>();
           
            claims.Add(new Claim("userId", userManager.FindUserId(user).ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user));

            
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);


            await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), authProperties);
        }
       
        public ActionResult OnPostAsync()
        {

            ILoginManager loginManager = new LoginManager(new DBUser());
            if (ModelState.IsValid)
            {
                User user = loginManager.CheckLogin(Login.password, Login.email);
                if (user != null)
                {
                    Auth(user.username);
                    return RedirectToPage("/Home");
                }
            }
            return Page();
        }

    }
}
