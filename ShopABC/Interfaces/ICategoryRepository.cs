using ShopABC.Entities;
using ShopABC.Models;

namespace ShopABC.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryModel>> GetAllCategoryAsync();
        public Task<CategoryModel> GetBookAsync(int id);
        public Task<int> AddBookAsync(CategoryModel model);
        public Task UpdateCategoryAsync(int id, CategoryModel model);
        public Task DeleteCategoryAsync(int id);
    }
}
