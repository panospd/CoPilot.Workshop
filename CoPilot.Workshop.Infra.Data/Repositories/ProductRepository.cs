// CoPilot.Workshop.Infra.Data/ProductRepository.cs
using CoPilot.Workshop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoPilot.Workshop.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
    }
}


