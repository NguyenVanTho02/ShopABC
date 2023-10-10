using ShopABC.Models;

namespace ShopABC.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<ProductModel>> GetAllProductAsync();
        public Task<ProductModel> GetProductAsync(int id);
        public Task<int> AddProductAsync(ProductModel model);
        public Task UpdateProductAsync(int id, ProductModel model);
        public Task DeleteProductAsync(int id);
        public Task<List<ProductModel>> Search(string name);
    }
}
