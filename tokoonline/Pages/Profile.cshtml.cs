using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tokoonline.Models;
using tokoonline.Services;

namespace tokoonline.Pages
{
    public class ProfileModel : PageModel
    {
        public User? CurrentUser { get; set; }

        public IActionResult OnGet()
        {
            string? email = HttpContext.Session.GetString("UserEmail");

            if (email == null)
            {
                return RedirectToPage("/Login");
            }

            List<User> users = UserService.GetUsers();

            CurrentUser = users.FirstOrDefault(x => x.Email == email);

            return Page();
        }
    }
}