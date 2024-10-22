using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SP_EF_Project1.Models;
using System.Runtime.CompilerServices;

namespace SP_EF_Project1.Repositories
{
    public class ProductService : IProductService
    {
        private readonly DbContextClass _dbContext;

        public ProductService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProductsListAsync()
        {

            return await _dbContext.Product.FromSqlRaw<Product>("GetProductList").ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProductByIdAsync(int ProductId)
        {
            var param = new SqlParameter("@ProductId", ProductId);

            var productDetails = await Task.Run(() => _dbContext.Product.FromSqlRaw(@"exec GetProductByID @ProductId", param).ToListAsync());
            return productDetails;
        }
        public async Task<int> AddProductAsync(Product product)
        {

            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductName", product.ProductName));
            param.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            param.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            param.Add(new SqlParameter("@ProductStock", product.ProductStock));

            var AddProduct = await Task.Run(() => _dbContext.Database.ExecuteSqlRawAsync(@"exec AddProduct @ProductName, @ProductDescription, @ProductPrice, @ProductStock", param.ToArray()));
            return AddProduct;

        }
        public async Task<int> UpdateProductAsync(Product product)
        {

            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@ProductId", product.ProductId));
            param.Add(new SqlParameter("@ProductName", product.ProductName));
            param.Add(new SqlParameter("@ProductDescription", product.ProductDescription));
            param.Add(new SqlParameter("@ProductPrice", product.ProductPrice));
            param.Add(new SqlParameter("@ProductStock", product.ProductStock));

            var UpdateProduct = await Task.Run(() => _dbContext.Database.ExecuteSqlRawAsync(@"exec UpdateProduct @ProductId, @ProductName, @ProductDescription, 
            @ProductPrice, @ProductStock", param.ToArray()));
            return UpdateProduct;
        }
        public async Task<int> DeleteProductAsync(int ProductId) 
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteProductByID { ProductId }"));
        }
        public async Task<List<ProductSales>> GetProductSalesListAsync()
        {
            //var sp_query = FormattableStringFactory.Create("EXEC GetProductSalesList");

            //return await _dbContext.Database.SqlQuery<ProductSales>(sp_query).ToListAsync();

            return await _dbContext.ProductSales.FromSqlRaw<ProductSales>("GetProductSalesList").ToListAsync();

        }

        public async Task<IEnumerable<ProductSales>> GetProductSalesListAsyncByID(int ProdID)
        {
            var param = new SqlParameter("@ProductID", ProdID);

            var sp_query = FormattableStringFactory.Create("EXEC GetProductSalesListByID @ProductID", param);

            return await _dbContext.Database.SqlQuery<ProductSales>(sp_query).ToListAsync();


        }

    }
}
