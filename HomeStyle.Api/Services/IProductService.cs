


using HomeStyler.Api.Data.Entities;
using HomeStyler.Shared.Responses;

namespace HomeStyler.Api.Services
{
    public interface IProductService
    {
        Task<ServiceResponse> AddProductAsync(Product product);
        Task<ServiceResponse> UpdateProductAsync(Product product);
        Task<ServiceResponse> DeleteProductAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
    }
}
