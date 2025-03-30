// CoPilot.Workshop.Domain/IProductRepository.cs
using CoPilot.Workshop.Domain;
using System.Threading.Tasks;

namespace CoPilot.Workshop.App.Products
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken cancellationToken = default);
    }
}

