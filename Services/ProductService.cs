using firstAsp.NetProject.Models;
using firstAsp.NetProject.Repositories;

namespace firstAsp.NetProject.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepositiory productRepositiory;

        public ProductService(IProductRepositiory productRepositiory)
        {
            this.productRepositiory = productRepositiory;
        }

        public async Task CreateProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (string.IsNullOrEmpty(product.ProductName))
                throw new ArgumentException("Product name cannot be null or empty.", nameof(product));
            if (product.UnitPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(product.UnitPrice), "Unit price cannot be negative.");
            if (product.UnitsInStock < 0)
                throw new ArgumentOutOfRangeException(nameof(product.UnitsInStock), "Units in stock cannot be negative.");
            if (product.UnitsOnOrder < 0)
                throw new ArgumentOutOfRangeException(nameof(product.UnitsOnOrder), "Units on order cannot be negative.");
            if (product.ReorderLevel < 0)
                throw new ArgumentOutOfRangeException(nameof(product.ReorderLevel), "Reorder level cannot be negative.");
            if (product.SupplierID <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.SupplierID), "Supplier ID must be greater than zero.");

            await productRepositiory.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (product.ProductID <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.ProductID), "Product ID must be greater than zero.");
            await productRepositiory.DeleteProductAsync(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await productRepositiory.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Product ID must be greater than zero.");
            return await productRepositiory.GetProductByIdAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (product.ProductID <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.ProductID), "Product ID must be greater than zero.");
            if (string.IsNullOrEmpty(product.ProductName))
                throw new ArgumentException("Product name cannot be null or empty.", nameof(product));
            if (product.UnitPrice < 0)
                throw new ArgumentOutOfRangeException(nameof(product.UnitPrice), "Unit price cannot be negative.");
            if (product.UnitsInStock < 0)
                throw new ArgumentOutOfRangeException(nameof(product.UnitsInStock), "Units in stock cannot be negative.");
            if (product.UnitsOnOrder < 0)
                throw new ArgumentOutOfRangeException(nameof(product.UnitsOnOrder), "Units on order cannot be negative.");
            if (product.ReorderLevel < 0)
                throw new ArgumentOutOfRangeException(nameof(product.ReorderLevel), "Reorder level cannot be negative.");
            if (product.SupplierID <= 0)
                throw new ArgumentOutOfRangeException(nameof(product.SupplierID), "Supplier ID must be greater than zero.");

            await productRepositiory.UpdateProductAsync(product);
        }
    }
}
