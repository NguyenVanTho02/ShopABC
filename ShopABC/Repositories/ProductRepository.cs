using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopABC.AppDbContext;
using ShopABC.Entities;
using ShopABC.Interfaces;
using ShopABC.Models;

namespace ShopABC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopABCContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ShopABCContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddProductAsync(ProductModel model)
        {
            var newProduct = _mapper.Map<Product>(model);
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return newProduct.Idproduct;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteProduct = _context.Products.SingleOrDefault(p => p.Idproduct == id);
            if(deleteProduct != null)
            {
                _context.Products.Remove(deleteProduct);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<ProductModel>> GetAllProductAsync()
        {
            var products = await _context.Products!.ToListAsync();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public async Task<ProductModel> GetProductAsync(int id)
        {
            var product =  await _context.Products.FindAsync(id);
            return _mapper.Map<ProductModel>(product);
        }

        public async Task<List<ProductModel>> Search(string name)
        {
            var products = await _context.Products.ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                var result = products.Where(c => c.Name.ToLower().Contains(name.ToLower()));
                return _mapper.Map<List<ProductModel>>(result);
            }
            return null;
        }

        public async Task UpdateProductAsync(int id, ProductModel model)
        {
            if (id == model.Idproduct)
            {
                var updateProduct = _mapper.Map<Product>(model);
                _context.Products!.Update(updateProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
