using ShopABC.Models;

namespace ShopABC.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> GetAllProductAsync(double? from, double? to, string? sortBy, int page = 1);
        public Task<ProductModel> GetProductAsync(int id);
        public Task<int> AddProductAsync(ProductModel model);
        public Task UpdateProductAsync(int id, ProductModel model);
        public Task DeleteProductAsync(int id);
        public Task<List<ProductModel>> Search(string name);
    }
}
