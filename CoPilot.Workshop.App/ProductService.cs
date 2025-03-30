using CoPilot.Workshop.Domain;

namespace CoPilot.Workshop.App
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(AddProductRequest productDto)
        {
            var product = Product.Create(
                productDto.Name,
                productDto.Description,
                productDto.Price
            );

            await _productRepository.CreateProductAsync(product);
        }
    }
}
