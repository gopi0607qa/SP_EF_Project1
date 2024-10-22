using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_EF_Project1.Models;
using SP_EF_Project1.Repositories;

namespace SP_EF_Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService) 
        {        
            this.productService = productService;
        }

        [HttpGet ("getProductList")]
        public async Task<List<Product>> GetProductsListAsync()
        {
            try
            {
                return await productService.GetProductsListAsync();
            }
            catch { 
                throw;
            }
        }
        
        [HttpGet("getProductByID")]
        public async Task<IEnumerable<Product>> GetProductByIdAsync(int Id)
        {
            try
            {
                var response = await productService.GetProductByIdAsync(Id);
                //if (response == null) {
                //    return null;
                //}
                return response;
            }
            catch
            {
                throw;
            }
        }
        
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await productService.AddProductAsync(product);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            try
            {
                var response = await productService.UpdateProductAsync(product);
                return Ok(response);
            }
            catch
            {
                throw;
            }
        }
        
        [HttpDelete("DeleteProduct")]
        public async Task<int> DeleteProductAsync(int Id)
        {
            try
            {
                var response = await productService.DeleteProductAsync(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("getProductSalesList")]
        public async Task<List<ProductSales>> GetProductSalesListAsync()
        {
            try
            {
                return await productService.GetProductSalesListAsync();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet("getProductSalesListByID")]
        public async Task<IEnumerable<ProductSales>> GetProductSalesListAsyncByID(int Id)
        {
            try
            {
                var response = await productService.GetProductSalesListAsyncByID(Id);
                //if (response == null) {
                //    return null;
                //}
                return response;
            }
            catch
            {
                throw;
            }
        }



    }
}
