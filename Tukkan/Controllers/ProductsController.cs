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
            var products = GetProducts(); // Ürünleri almak için bir yöntem
            return View(products);
        }

        public IActionResult Cart()
        {
            return View(_cart); // Sepet modelini view'a gönder
        }

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = GetProductById(productId); // Ürünü almak için bir yöntem
            if (product != null)
            {
                _cart.AddProduct(product);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int productId)
        {
            _cart.RemoveProduct(productId);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult IncreaseQuantity(int productId)
        {
            _cart.IncreaseQuantity(productId);
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult DecreaseQuantity(int productId)
        {
            _cart.DecreaseQuantity(productId);
            return RedirectToAction("Cart");
        }

        private Product GetProductById(int productId)
        {
            return new Product { Id = productId, Name = $"Ürün {productId}", Price = 100, Description="Örnek Ürün Açıklaması", Stock=15 }; // Örnek ürün
        }

        private List<Product> GetProducts()
        {
            return new List<Product>
    {
        new Product { Id = 1, Name = "Ürün 1", Price = 100, Description = "Ürün 1 açıklaması.",Stock=10 },
        new Product { Id = 2, Name = "Ürün 2", Price = 150, Description = "Ürün 2 açıklaması.", Stock=15 },
        new Product { Id = 3, Name = "Ürün 3", Price = 200, Description = "Ürün 3 açıklaması.", Stock= 15 }
    };
        }


        [HttpPost]
        public IActionResult Clear()
        {
            _cart.Clear();
            return RedirectToAction("Cart");
        }

        public IActionResult Details(int id)
        {
            var product = GetProducts().FirstOrDefault(p => p.Id == id); // Sabit ürün listesinden bul
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

       

    }
}
