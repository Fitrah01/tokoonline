using Newtonsoft.Json;
using tokoonline.Models;

namespace tokoonline.Services
{
    public static class ProductService
    {
        private static string filePath = "products.json";

        private static string cartPath = "cart.json";

        public static List<Product> GetProducts()
        {
            if (!File.Exists(filePath))
            {
                return new List<Product>();
            }

            string json = File.ReadAllText(filePath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Product>();
            }

            return JsonConvert.DeserializeObject<List<Product>>(json)
                   ?? new List<Product>();
        }

        public static void SaveProducts(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        public static List<Product> GetCart()
        {
            if (!File.Exists(cartPath))
            {
                return new List<Product>();
            }

            string json = File.ReadAllText(cartPath);

            if (string.IsNullOrEmpty(json))
            {
                return new List<Product>();
            }

            return JsonConvert.DeserializeObject<List<Product>>(json)
                   ?? new List<Product>();
        }

        public static void SaveCart(List<Product> cart)
        {
            string json = JsonConvert.SerializeObject(cart, Formatting.Indented);

            File.WriteAllText(cartPath, json);
        }
    }
}