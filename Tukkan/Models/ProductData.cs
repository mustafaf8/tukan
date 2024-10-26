using System.Collections.Generic;

namespace Tukkan.Models
{
    public static class ProductData
    {
        public static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Ürün 1", Price = 100, Description = "Elektronik Ürün 1 açıklaması.", Stock = 10, Category = "Elektronik", ImageUrl = "/images/urun1.jpg" },
            new Product { Id = 2, Name = "Ürün 2", Price = 150, Description = "Kitap Ürün 2 açıklaması.", Stock = 15, Category = "Kitap", ImageUrl = "/images/urun2.jpg" },
            new Product { Id = 3, Name = "Ürün 3", Price = 200, Description = "Giyim Ürün 3 açıklaması.", Stock = 15, Category = "Giyim", ImageUrl = "/images/urun3.jpg" },
            new Product { Id = 4, Name = "Ürün 4", Price = 250, Description = "Elektronik Ürün 4 açıklaması.", Stock = 8, Category = "Elektronik", ImageUrl = "/images/urun4.jpg" },
            new Product { Id = 5, Name = "Ürün 5", Price = 300, Description = "Kitap Ürün 5 açıklaması.", Stock = 12, Category = "Kitap", ImageUrl = "/images/urun5.jpg" },
            new Product { Id = 6, Name = "Ürün 9", Price = 75, Description = "Giyim Ürün 6 açıklaması.", Stock = 20, Category = "Giyim", ImageUrl = "/images/urun6.jpg" }
        };
    }
}
