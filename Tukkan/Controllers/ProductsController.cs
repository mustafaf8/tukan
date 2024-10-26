using Microsoft.AspNetCore.Mvc;
using Tukkan.Models;
using System.Linq;
using System.Collections.Generic;

namespace Tukkan.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Cart _cart;

        public ProductsController(Cart cart)
        {
            _cart = cart;
        }

        public IActionResult Index(string category = null, bool randomOrder = false)
        {
            var products = ProductData.Products;

            // Kategoriye göre filtreleme
            if (!string.IsNullOrEmpty(category))
            {
                products = products.Where(p => p.Category == category).ToList();
            }

            // Rastgele sıralama
            if (randomOrder)
            {
                products = products.OrderBy(p => System.Guid.NewGuid()).ToList();
            }

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

        public IActionResult Details(int id)
        {
            var product = GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult Clear()
        {
            _cart.Clear();
            return RedirectToAction("Cart");
        }

        private Product GetProductById(int productId)
        {
            return ProductData.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}
