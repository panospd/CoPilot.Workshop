// CoPilot.Workshop.App/Products/GetAll/GetAllProductsHandler.cs
using CoPilot.Workshop.Domain;
using CoPilot.Workshop.Framework;

namespace CoPilot.Workshop.App.Products.GetAll
{
    public class GetAllProductsHandler : BaseHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        protected override async Task<IEnumerable<Product>> ExecuteAsync(GetAllProductsQuery request, CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetAllProductsAsync(cancellationToken);
        }
    }
}
