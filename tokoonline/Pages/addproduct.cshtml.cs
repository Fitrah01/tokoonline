using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tokoonline.Models;

namespace tokoonline.Pages
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public string Image { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            var product = new Product
            {
                Name = Name,
                Price = Price,
                Image = Image
            };

            return RedirectToPage("Index");
        }
    }
}