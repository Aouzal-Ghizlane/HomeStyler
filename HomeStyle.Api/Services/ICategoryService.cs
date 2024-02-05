

using HomeStyler.Api.Data.Entities;

namespace HomeStyler.Api.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
    }
}