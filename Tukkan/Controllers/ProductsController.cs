using Microsoft.AspNetCore.Mvc;
using Tukkan.Models;

namespace Tukkan.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Cart _cart;

        public ProductsController(Cart cart)
        {
            _cart = cart;
        }

        public IActionResult Index()
        {
            // Ürünleri buradan alarak Model'e geçebilirsiniz
            var products = GetProducts(); // Ürünleri almak için bir yöntem (örnek)
            return View(products);
        }

        public IActionResult Cart()
        {
            return View(_cart); // Sepet modelini view'a gönder
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            // Ürünü sepete ekle
            var product = GetProductById(productId); // Ürünü almak için bir yöntem (örnek)
            if (product != null)
            {
                _cart.AddProduct(product);
            }
            return RedirectToAction("Index"); // Ürün listesine yönlendir
        }

        private Product GetProductById(int productId)
        {
            // Burada ürün bilgilerini veritabanından veya bir listeden almanız gerekiyor
            // Örnek olarak hardcoded bir ürün dönebiliriz
            return new Product { Id = productId, Name = $"Ürün {productId}", Price = 100 }; // Örnek ürün
        }

        private List<Product> GetProducts()
        {
            // Burada tüm ürünleri veritabanından veya bir listeden almanız gerekiyor
            // Örnek olarak hardcoded bir ürün listesi dönebiliriz
            return new List<Product>
            {
                new Product { Id = 1, Name = "Ürün 1", Price = 100 },
                new Product { Id = 2, Name = "Ürün 2", Price = 150 },
                new Product { Id = 3, Name = "Ürün 3", Price = 200 }
            };
        }
    }
}
