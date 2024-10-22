using SP_EF_Project1.Models;

namespace SP_EF_Project1.Repositories
{
    public interface IProductService
    {

        public Task<List<Product>> GetProductsListAsync();
        public Task<IEnumerable<Product>> GetProductByIdAsync(int Id);
        public Task<int> AddProductAsync(Product product);
        public Task<int> UpdateProductAsync(Product product);
        public Task<int> DeleteProductAsync(int Id);
        public Task<List<ProductSales>> GetProductSalesListAsync();
        public Task<IEnumerable<ProductSales>> GetProductSalesListAsyncByID(int ProdID);

    }
}
