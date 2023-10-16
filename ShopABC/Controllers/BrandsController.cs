using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopABC.Interfaces;
using ShopABC.Models;

namespace ShopABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepo;

        public BrandsController(IBrandRepository repo)
        {
            _brandRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            try
            {
                return Ok(await _brandRepo.GetAllBrandAsync());
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            try
            {
                var brand = await _brandRepo.GetBrandAsync(id);
                return brand == null ? NotFound() : Ok(brand);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("Search/{value}")]
        public async Task<IActionResult> SearchBrand(string value)
        {
            try
            {
                var brands = await _brandRepo.Search(value);
                return brands == null ? NotFound() : Ok(brands);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBrand(BrandModel model)
        {
            try
            {
                var newBrandId = await _brandRepo.AddBrandAsync(model);
                var brand = await _brandRepo.GetBrandAsync(newBrandId);
                return brand == null ? NotFound() : Ok(brand);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrand(int id, BrandModel model)
        {
            try
            {
                if(id != model.Idbrand)
                {
                    return NotFound();
                }
                await _brandRepo.UpdateBrandAsync(id, model);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            try
            {
                await _brandRepo.DeleteBrandAsync(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

    }
}
