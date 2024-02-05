
using HomeStyler.Api.Data;
using HomeStyler.Api.Data.Entities;



namespace HomeStyler.Api.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext appDbContext;

        public CategoryService(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Category>> GetCategoriesAsync() => await appDbContext.Categories.ToListAsync();
    }
}