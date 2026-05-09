using Microsoft.AspNetCore.Mvc.RazorPages;
using tokoonline.Models;

namespace tokoonline.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }

        public bool IsLogin { get; set; }

        public void OnGet()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            IsLogin = !string.IsNullOrEmpty(email);

            Products = new List<Product>
            {
                new Product { Id = 1, Name = "Produk A", Price = 10000, Image = "" },
                new Product { Id = 2, Name = "Produk B", Price = 20000, Image = "" }
            };
        }
    }
}