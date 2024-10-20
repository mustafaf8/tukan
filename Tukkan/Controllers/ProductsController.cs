using Microsoft.AspNetCore.Mvc;
using Tukkan.Models;
using System.Collections.Generic;

namespace Tukkan.Controllers
{
    public class ProductsController : Controller
    {
        private List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Ürün 1", Description = "Açıklama 1", Price = 100 },
            new Product { Id = 2, Name = "Ürün 2", Description = "Açıklama 2", Price = 200 },
            new Product { Id = 3, Name = "Ürün 3", Description = "Açıklama 3", Price = 300 }
        };

        // Ürün Listeleme
        public IActionResult Index()
        {
            return View(products);
        }

        // Ürün Detayı
        public IActionResult Details(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // Sepet
        public IActionResult Cart()
        {
            return View(products);
        }
    }
}
