using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopABC.AppDbContext;
using ShopABC.Entities;
using ShopABC.Interfaces;
using ShopABC.Models;

namespace ShopABC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopABCContext _context;
        private readonly IMapper _mapper;

        public CategoryRepository(ShopABCContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddCategoryAsync(CategoryModel model)
        {
            var newCategory = _mapper.Map<Category>(model);
            _context.Categories!.Add(newCategory);
            await _context.SaveChangesAsync();

            return newCategory.Idcategory;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var deleteCategory = _context.Categories!.SingleOrDefault(c => c.Idcategory == id);
            if(deleteCategory != null) 
            {
                _context.Categories!.Remove(deleteCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CategoryModel>> GetAllCategoryAsync()
        {
            var catagories = await _context.Categories!.ToListAsync();
            return _mapper.Map<List<CategoryModel>>(catagories);
        }

        public async Task<CategoryModel> GetCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return _mapper.Map<CategoryModel>(category);
        }

        public async Task UpdateCategoryAsync(int id, CategoryModel model)
        {
            if(id == model.Idcategory)
            {
                var updateCategory = _mapper.Map<Category>(model);
                _context.Categories!.Update(updateCategory);

                await _context.SaveChangesAsync();
            }
        }
    }
}
