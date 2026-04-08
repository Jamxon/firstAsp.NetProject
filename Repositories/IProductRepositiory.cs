using firstAsp.NetProject.Data;
using firstAsp.NetProject.Models;
namespace firstAsp.NetProject.Repositories
{
    public interface IProductRepositiory
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}
