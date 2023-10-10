using ShopABC.Models;

namespace ShopABC.Interfaces
{
    public interface IBrandRepository
    {
        public Task<List<BrandModel>> GetAllProductAsync();
        public Task<BrandModel> GetProductAsync(int id);
        public Task<int> AddProductAsync(BrandModel model);
        public Task UpdateProductAsync(int id, BrandModel model);
        public Task DeleteProductAsync(int id);
        public Task<List<BrandModel>> Search(string name);
    }
}
