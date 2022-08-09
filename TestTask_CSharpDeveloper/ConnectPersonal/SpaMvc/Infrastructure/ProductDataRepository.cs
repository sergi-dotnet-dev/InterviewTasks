using SpaMvc.DAL;
using SpaMvc.Infrastructure.Abstract;
using SpaMvc.Models;

namespace SpaMvc.Infrastructure
{
    public class ProductDataRepository : IDataRepository<Product>
    {
        private readonly ApplicationContext _context;

        public ProductDataRepository(ApplicationContext context) 
            => _context = context;
        public IQueryable<Product> Data => _context.Products;
    }
}
