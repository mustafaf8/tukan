using System.Collections.Generic;
using Tukkan.Models;

namespace Tukkan.Models
{
    public class Cart
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void Clear()
        {
            Products.Clear();
        }
    }
}