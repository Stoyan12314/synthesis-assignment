using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTO;
namespace Synthesis_Assignments.Pages
{
    public class IndexModel : PageModel
    {
      [BindProperty] public Login Login { get; set;}
     

        public IndexModel()
        {
            
        }

        public void OnGet()
        {

        }
    }
}
