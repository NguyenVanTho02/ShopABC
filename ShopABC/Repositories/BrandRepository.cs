using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopABC.AppDbContext;
using ShopABC.Entities;
using ShopABC.Interfaces;
using ShopABC.Models;

namespace ShopABC.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ShopABCContext _context;
        private readonly IMapper _mapper;
        public BrandRepository(ShopABCContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public async Task<int> AddProductAsync(BrandModel model)
        {
            var newBrand = _mapper.Map<Brand>(model);
            _context.Brands!.Add(newBrand);
            await _context.SaveChangesAsync();

            return newBrand.Idbrand;
        }

        public async Task DeleteProductAsync(int id)
        {
            var deleteBrand = _context.Brands!.SingleOrDefault(b => b.Idbrand == id);
            if (deleteBrand != null)
            {
                _context.Brands!.Remove(deleteBrand);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BrandModel>> GetAllProductAsync()
        {
            var brands = await _context.Brands!.ToListAsync();
            return _mapper.Map<List<BrandModel>>(brands);
        }

        public async Task<BrandModel> GetProductAsync(int id)
        {
            var brand = await _context.Brands!.FindAsync(id);
            return _mapper.Map<BrandModel>(brand);
        }

        public async Task<List<BrandModel>> Search(string name)
        {
            var brands = await _context.Brands!.ToListAsync();
            if (!string.IsNullOrEmpty(name))
            {
                var result = brands.Where(b => b.NameBrand.ToLower().Contains(name.ToLower()));
                return _mapper.Map<List<BrandModel>>(result);
            }
            return null;
        }

        public async Task UpdateProductAsync(int id, BrandModel model)
        {
            if (id == model.Idbrand)
            {
                var updateBrand = _mapper.Map<Brand>(model);
                _context.Brands!.Update(updateBrand);

                await _context.SaveChangesAsync();
            }
        }
    }
}
