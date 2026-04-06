using Microsoft.AspNetCore.Mvc;
using firstAsp.NetProject.Models;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace firstAsp.NetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        protected readonly IDbConnection _db;

        public ProductsController(IDbConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var sql = "SELECT * FROM Products\r\nORDER BY productID DESC";

            var products = await _db.QueryAsync<Product>(sql);

            return products;
        }

        [HttpPost]
        public async Task<bool> Post(Product product)
        {
            var sql = @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
                        VALUES (@ProductName, @SupplierID, @CategoryID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)";
            var result = await _db.ExecuteAsync(sql, product);
            if (result > 0)
                return true;
            else
                return false;
        }

        [HttpPut]
        public async Task<bool> Put(Product product)
        {
            var sql = @"UPDATE Products 
                SET ProductName = @ProductName,
                    SupplierID = @SupplierID,
                    CategoryID = @CategoryID,
                    QuantityPerUnit = @QuantityPerUnit,
                    UnitPrice = @UnitPrice,
                    UnitsInStock = @UnitsInStock,
                    UnitsOnOrder = @UnitsOnOrder,
                    ReorderLevel = @ReorderLevel,
                    Discontinued = @Discontinued
                WHERE ProductID = @ProductID";

            var result = await _db.ExecuteAsync(sql, product);

            return result > 0;
        }

        [HttpDelete]
        public async Task<bool> Delete(Product product)
        {
            var sql = "Delete from Products where ProductID = @productID";

            var result = await _db.ExecuteAsync(sql, product);

            return result > 0;
        }
    }
}