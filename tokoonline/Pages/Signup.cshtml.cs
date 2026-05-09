using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tokoonline.Models;
using tokoonline.Services;

namespace tokoonline.Pages
{
    public class SignupModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = "";

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string Message { get; set; } = "";

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            List<User> users = UserService.GetUsers();

            bool emailExist = users.Any(x => x.Email == Email);

            if (emailExist)
            {
                Message = "Email sudah digunakan";

                return Page();
            }

            User user = new User();

            user.Id = users.Count + 1;
            user.Name = Name;
            user.Email = Email;
            user.Password = Password;

            users.Add(user);

            UserService.SaveUsers(users);

            return RedirectToPage("/Login");
        }
    }
}