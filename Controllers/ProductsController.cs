using Microsoft.AspNetCore.Mvc;
using firstAsp.NetProject.Models;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using firstAsp.NetProject.Services;

namespace firstAsp.NetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {    
            return await _productService.GetAllProductsAsync();
        }

        [HttpPost]
        public async Task<bool> Post(Product product)
        {
            await this._productService.CreateProductAsync(product);
            return true;
        }

        [HttpPut]
        public async Task<bool> Put(Product product)
        {
            await this._productService.UpdateProductAsync(product);
            return true;
        }

        [HttpDelete]
        public async Task<bool> Delete(Product product)
        {
            await this._productService.DeleteProductAsync(product);
            return true;
        }
    }
}