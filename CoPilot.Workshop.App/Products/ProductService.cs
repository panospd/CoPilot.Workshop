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
        /// Retrieves all products asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of products.</returns>
        public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetAllProductsAsync(cancellationToken);
        }
    }
}
