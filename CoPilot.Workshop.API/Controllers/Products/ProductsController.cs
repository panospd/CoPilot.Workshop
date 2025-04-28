using CoPilot.Workshop.App;
using CoPilot.Workshop.App.Products;
using CoPilot.Workshop.App.Products.Create;
using CoPilot.Workshop.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CoPilot.Workshop.API.Controllers.Products
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
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto, [FromServices] CreateProductHandler handler, CancellationToken cancellationToken)
        {
            await handler.HandleAsync(new AddProductRequest(productDto.Name, productDto.Description, productDto.Price), cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync(CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllProductsAsync(cancellationToken);
            return Ok(products);
        }
    }
}
