using CoPilot.Workshop.App;
using CoPilot.Workshop.App.Products;
using CoPilot.Workshop.App.Products.Create;
using CoPilot.Workshop.App.Products.GetAll;
using CoPilot.Workshop.Domain;
using Microsoft.AspNetCore.Mvc;
using static CoPilot.Workshop.App.Products.Create.CreateProductCommand;

namespace CoPilot.Workshop.API.Controllers.Products
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto, [FromServices] CreateProductHandler handler, CancellationToken cancellationToken)
        {
            await handler.HandleAsync(new CreateProductCommand(productDto.Name, productDto.Description, productDto.Price), cancellationToken);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductsAsync(
            [FromServices] GetAllProductsHandler handler,
            CancellationToken cancellationToken)
        {
            var products = await handler.HandleAsync(new GetAllProductsQuery(), cancellationToken);
            return Ok(products);
        }
    }
}
