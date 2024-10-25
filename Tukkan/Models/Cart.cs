using System.Collections.Generic;
using System.Linq;

namespace Tukkan.Models
{
    public class Cart
    {
        // Sepetteki ürünleri tutacak liste
        private List<CartProductItem> _items = new List<CartProductItem>();

        // Sepet içindeki ürünleri dışarıya sunan özellik
        public List<CartProductItem> Items => _items;

        // Ürün ekleme metodu
        public void AddProduct(Product product)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
            else
            {
                _items.Add(new CartProductItem { Product = product, Quantity = 1 });
            }
        }

        // Ürün çıkarma metodu
        public void RemoveProduct(int productId)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem != null)
            {
                _items.Remove(cartItem);
            }
        }

        // Ürün miktarını artırma metodu
        public void IncreaseQuantity(int productId)
        {
            var cartItem = _items.FirstOrDefault(i => i.Product.Id == productId);
            if (cartItem != null)
            {
                cartItem.Quantity++;
            }
        }

        // Ürün miktarını azaltma metodu
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

        // Toplam tutarı hesaplayan özellik
        public decimal TotalAmount => _items.Sum(i => i.Product.Price * i.Quantity);

        // Sepeti temizleme metodu
        public void Clear()
        {
            _items.Clear();
        }
    }
}
