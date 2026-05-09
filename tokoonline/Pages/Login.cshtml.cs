using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace tokoonline.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (Email == "admin@gmail.com" && Password == "12345")
            {
                HttpContext.Session.SetString("UserEmail", Email);

                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}