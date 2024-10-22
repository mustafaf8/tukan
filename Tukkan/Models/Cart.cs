using System.Collections.Generic;
using System.Linq;

namespace Tukkan.Models
{
    public class Cart
    {
        public List<CartItem> Products { get; set; } = new List<CartItem>();

        public void AddProduct(Product product)
        {
            var cartItem = Products.FirstOrDefault(p => p.Product.Id == product.Id);
            if (cartItem == null)
            {
                Products.Add(new CartItem { Product = product, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }
        }

        public void RemoveProduct(int productId)
        {
            var cartItem = Products.FirstOrDefault(p => p.Product.Id == productId);
            if (cartItem != null)
            {
                Products.Remove(cartItem);
            }
        }

        public void IncreaseQuantity(int productId)
        {
            var cartItem = Products.FirstOrDefault(p => p.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
        }

        public void DecreaseQuantity(int productId)
        {
            var cartItem = Products.FirstOrDefault(p => p.Product.Id == productId);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    Products.Remove(cartItem);
                }
            }
        }

        public void Clear()
        {
            Products.Clear();
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
