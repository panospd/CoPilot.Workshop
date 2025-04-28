using CoPilot.Workshop.Domain;
using CoPilot.Workshop.Framework;

namespace CoPilot.Workshop.App.Products.Create
{
    /// <summary>  
    /// Handler for creating products.  
    /// </summary>
    public class CreateProductHandler : BaseHandler<AddProductRequest, AddProductRequestValidator>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>  
        /// Initializes a new instance of the <see cref="CreateProductHandler"/> class.  
        /// </summary>  
        /// <param name="productRepository">The product repository.</param>  
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>  
        /// Creates a new product asynchronously.  
        /// </summary>  
        /// <param name="productDto">The product data transfer object.</param>  
        /// <param name="cancellationToken">The cancellation token.</param>  
        /// <returns>A task that represents the asynchronous operation.</returns>

        public override async Task ExecuteAsync(AddProductRequest request, CancellationToken cancellationToken = default)
        {
            var product = Product.Create(
                request.Name,
                request.Description,
                request.Price
            );

            await _productRepository.CreateProductAsync(product, cancellationToken);
        }
    }
}
