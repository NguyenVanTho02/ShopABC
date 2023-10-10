using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopABC.Interfaces;
using ShopABC.Models;

namespace ShopABC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductsController(IProductRepository repo)
        {
            _productRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            try
            {
                return Ok(await _productRepo.GetAllProductAsync());
            } catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _productRepo.GetProductAsync(id);
                return product == null ? NotFound() : Ok(product);
            } catch
            {
                return NotFound();
            }
        }

        [HttpGet("Search/{value}")]
        public async Task<IActionResult> SearchProduct(string value)
        {
            try
            {
                var products = await _productRepo.Search(value);
                return products == null ? NotFound() : Ok(products);
            } catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProduct(ProductModel model)
        {
            try
            {
                var newProductId = await _productRepo.AddProductAsync(model);
                var productNew = await _productRepo.GetProductAsync(newProductId);
                return productNew == null ? NotFound() : Ok(productNew);
            } catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductModel model)
        {
            try
            {
                if(id != model.Idproduct)
                {
                    return NotFound();
                }
                await _productRepo.UpdateProductAsync(id,model);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productRepo.DeleteProductAsync(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}
