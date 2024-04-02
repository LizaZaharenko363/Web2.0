using WebApplication9.Models;

namespace WebApplication9.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task AddProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
