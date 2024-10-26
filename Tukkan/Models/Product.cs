namespace Tukkan.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        // Yeni özellikler
        public string Category { get; set; } // Ürün kategorisi
        public string ImageUrl { get; set; } // Ürün görsel URL'si
    }
}
