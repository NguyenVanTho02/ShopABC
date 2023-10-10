using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopABC.Entities;
using ShopABC.Interfaces;
using ShopABC.Models;

namespace ShopABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoriesController(ICategoryRepository repo)
        {
            _categoryRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                return Ok(await _categoryRepo.GetAllCategoryAsync());
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryRepo.GetCategoryAsync(id);
                return category == null ? NotFound() : Ok(category);
            } catch
            {
                return BadRequest();
            } 
        }

        [HttpGet("Search/{value}")]
        public async Task<IActionResult> SearchCategory(string value)
        {
            try
            {
                var categories = await _categoryRepo.Search(value);
                return categories == null ? NotFound() : Ok(categories);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCategory(CategoryModel model)
        {
            try
            {
                var newCategoryId = await _categoryRepo.AddCategoryAsync(model);
                var category = await _categoryRepo.GetCategoryAsync(newCategoryId);
                return category == null ? NotFound() : Ok(category);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryModel model)
        {
            try
            {
                if(id != model.Idcategory)
                {
                    return NotFound();
                }
                await _categoryRepo.UpdateCategoryAsync(id, model);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryRepo.DeleteCategoryAsync(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
