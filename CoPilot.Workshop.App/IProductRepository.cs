// CoPilot.Workshop.Domain/IProductRepository.cs
using System.Threading.Tasks;

namespace CoPilot.Workshop.Domain
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);
    }
}

