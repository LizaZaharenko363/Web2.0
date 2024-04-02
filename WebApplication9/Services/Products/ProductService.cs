using WebApplication9.Models;


namespace WebApplication9.Services.Products
    {
        public class ProductService : IProductService
        {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Matte Liquid Lipstick", Price = 12.99m },
            new Product { Id = 2, Name = "Foundation Primer", Price = 15.99m },
            new Product { Id = 3, Name = "Eyeshadow Palette", Price = 24.99m },
            new Product { Id = 4, Name = "Blush Compact", Price = 0.99m },
            new Product { Id = 5, Name = "Mascara", Price = 8.59m },
            new Product { Id = 6, Name = "Highlighter Stick", Price = 11.79m },
            new Product { Id = 7, Name = "Makeup Setting Spray", Price = 17.99m },
            new Product { Id = 8, Name = "Concealer Pen", Price = 7.89m },
            new Product { Id = 9, Name = "Eyebrow Pencil", Price = 5.99m },
            new Product { Id = 10, Name = "Gel Eyeliner", Price = 10.29m }
        };

        public async Task<IEnumerable<Product>> GetProducts()
            {
                return await Task.FromResult(_products);
            }

            public async Task AddProduct(Product product)
            {
                _products.Add(product);
                await Task.CompletedTask;
            }

            public async Task UpdateProduct(Product product)
            {
                var existingProduct = _products.Find(p => p.Id == product.Id);
                if (existingProduct != null)
                {
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }
                await Task.CompletedTask;
            }


            public async Task DeleteProduct(int id)
            {
                _products.RemoveAll(p => p.Id == id);
                await Task.CompletedTask;
            }
        }
    }

