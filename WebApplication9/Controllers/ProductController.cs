using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplication9.Models;
using WebApplication9.Services.Products;

namespace WebAplication7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] 
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product product)
        {
            await _productService.AddProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
