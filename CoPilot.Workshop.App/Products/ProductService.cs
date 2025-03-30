using CoPilot.Workshop.Domain;

namespace CoPilot.Workshop.App.Products
{
    /// <summary>
    /// Service for managing products.
    /// </summary>
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Creates a new product asynchronously.
        /// </summary>
        /// <param name="productDto">The product data transfer object.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateProductAsync(AddProductRequest productDto, CancellationToken cancellationToken = default)
        {
            var product = Product.Create(
                productDto.Name,
                productDto.Description,
                productDto.Price
            );

            await _productRepository.CreateProductAsync(product, cancellationToken);
        }
    }
}
