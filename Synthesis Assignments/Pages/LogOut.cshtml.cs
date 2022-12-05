using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Synthesis_Assignments.Pages
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToPage("/index");
        }
    }
}
