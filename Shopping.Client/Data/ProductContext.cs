using Shopping.Client.Models;

namespace Shopping.Client.Data
{
    public static class ProductContext
    {
        public static readonly List<Product> Products = new List<Product>
        {
            new Product
            {
                Name = "iPhone X",
                Description = "Apple iPhone X with 64GB storage and Face ID.",
                ImageFile = "product-1.png",
                Price = 950,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "Samsung Galaxy S23",
                Description = "Samsung flagship smartphone with AMOLED display.",
                ImageFile = "product-2.png",
                Price = 899,
                Category = "Smart Phone"
            },
            new Product
            {
                Name = "MacBook Air M2",
                Description = "Apple MacBook Air with M2 chip and 13.6-inch Retina display.",
                ImageFile = "product-3.png",
                Price = 1299,
                Category = "Laptop"
            },
            new Product
            {
                Name = "Sony WH-1000XM5",
                Description = "Wireless noise-cancelling over-ear headphones.",
                ImageFile = "product-4.png",
                Price = 399,
                Category = "Headphones"
            },
            new Product
            {
                Name = "Apple Watch Series 9",
                Description = "Smartwatch with fitness tracking and health monitoring.",
                ImageFile = "product-5.png",
                Price = 499,
                Category = "Smart Watch"
            }
        };
    }
}