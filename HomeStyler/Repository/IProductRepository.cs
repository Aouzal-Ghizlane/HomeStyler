
using HomeStyler.Models;


namespace HomeStyler.Repository
{
    public interface IProductRepository
    {
        //Task<List<Product>> GetProducts();
        //Task<Product> GetProductById(int productId);
        //Task<Product> AddProduct(Product newProduct);
        //
        Task<ServiceResponse> DeleteProductAsync(int productId);
        Task<List<ProductTem>> LoadProductsAsync();
        Task<List<Category>> GetCategoriesAsync();
        Task<ServiceResponse> AddProductAsync(Product product);
    }
}
