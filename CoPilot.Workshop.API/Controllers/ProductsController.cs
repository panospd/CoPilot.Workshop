using CoPilot.Workshop.App;
using CoPilot.Workshop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CoPilot.Workshop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            await _productService.CreateProductAsync(new AddProductRequest(productDto.Name, productDto.Description, productDto.Price));
            return Ok();
        }
    }
}
