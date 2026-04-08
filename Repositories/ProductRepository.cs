using firstAsp.NetProject.Data;
using firstAsp.NetProject.Models;
using System.Data;
using Dapper;

namespace firstAsp.NetProject.Repositories
{
    public class ProductRepository : IProductRepositiory
    {
        private readonly ApplicationDbContext _DbContext;
        private IDbConnection dbConnection;
        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _DbContext = applicationDbContext;
            dbConnection = _DbContext.CreateConnection();
        }

        public Task CreateProductAsync(Product product)
        {
            string sql = "INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                      "VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";

            var parameters = new
            {
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };

            return dbConnection.ExecuteAsync(sql, parameters);
        }

        public Task DeleteProductAsync(Product product)
        {
            string sql = "DELETE FROM Products WHERE ProductID = @ProductID";
            var parameters = new { ProductID = product.ProductID };
            return dbConnection.ExecuteAsync(sql, parameters);
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            string sql = "SELECT * FROM Products ORDER BY ProductID DESC";
            return dbConnection.QueryAsync<Product>(sql);
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductID = @ProductID";
            var parameters = new { ProductID = id };
            return dbConnection.QueryFirstOrDefaultAsync<Product>(sql, parameters);
        }

        public Task UpdateProductAsync(Product product)
        {
            string sql = "UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, CategoryID = @CategoryID, " +
                         "QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, " +
                         "UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued " +
                         "WHERE ProductID = @ProductID";
            var parameters = new
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };
            return dbConnection.ExecuteAsync(sql, parameters);
        }
    }
}
