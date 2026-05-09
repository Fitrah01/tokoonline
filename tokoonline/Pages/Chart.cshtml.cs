using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using tokoonline.Models;
using tokoonline.Services;

namespace tokoonline.Pages
{
    public class ChartModel : PageModel
    {
        public List<Product> CartItems { get; set; } = new();

        public decimal Total { get; set; }

        public void OnGet()
        {
            CartItems = ProductService.GetCart();

            Total = CartItems.Sum(x => x.Price);
        }

        public IActionResult OnPostRemove(int id)
        {
            List<Product> cart = ProductService.GetCart();

            Product? product = cart.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                cart.Remove(product);

                ProductService.SaveCart(cart);
            }

            return RedirectToPage();
        }
    }
}