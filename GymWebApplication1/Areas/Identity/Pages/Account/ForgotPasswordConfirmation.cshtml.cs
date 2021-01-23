using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GymWebApplication1.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        public void OnGet()
        {
        }
    }
}
