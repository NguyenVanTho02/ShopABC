using ShopABC.Models;

namespace ShopABC.Interfaces
{
    public interface IBrandRepository
    {
        public Task<List<BrandModel>> GetAllBrandAsync();
        public Task<BrandModel> GetBrandAsync(int id);
        public Task<int> AddBrandAsync(BrandModel model);
        public Task UpdateBrandAsync(int id, BrandModel model);
        public Task DeleteBrandAsync(int id);
        public Task<List<BrandModel>> Search(string name);
    }
}
