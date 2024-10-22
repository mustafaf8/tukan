using System.Collections.Generic;
using System.Linq;

namespace Tukkan.Models
{
    public class Cart
    {
        private List<CartItem> _items = new List<CartItem>();

        public void AddProduct(Product product)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                _items.Add(new CartItem { Product = product, Quantity = 1 });
            }
        }

        public void RemoveProduct(int productId)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem != null)
            {
                _items.Remove(cartItem);
            }
        }

        public void Clear()
        {
            _items.Clear();
        }

        public void IncreaseQuantity(int productId)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
        }

        public void DecreaseQuantity(int productId)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem != null && cartItem.Quantity > 1)
            {
                cartItem.Quantity--;
            }
            else if (cartItem != null && cartItem.Quantity == 1)
            {
                RemoveProduct(productId);
            }
        }

        public List<CartItem> Items => _items;

        // Toplam tutarı hesaplayan metot
        public decimal TotalAmount => _items.Sum(i => i.Product.Price * i.Quantity);
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
