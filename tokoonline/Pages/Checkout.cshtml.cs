using Microsoft.AspNetCore.Mvc.RazorPages;
using tokoonline.Models;
using tokoonline.Services;

namespace tokoonline.Pages
{
    public class CheckoutModel : PageModel
    {
        public decimal Total { get; set; }

        public void OnGet()
        {
            List<Product> cart = ProductService.GetCart();

            Total = cart.Sum(x => x.Price);
        }
    }
}