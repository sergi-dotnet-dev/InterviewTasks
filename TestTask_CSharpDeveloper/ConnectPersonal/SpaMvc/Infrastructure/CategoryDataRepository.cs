using SpaMvc.DAL;
using SpaMvc.Infrastructure.Abstract;
using SpaMvc.Models;

namespace SpaMvc.Infrastructure
{
    public class CategoryDataRepository : IDataRepository<Category>
    {
        private readonly ApplicationContext _context;

        public CategoryDataRepository(ApplicationContext context)
            => _context = context;
        public IQueryable<Category> Data => _context.Category;
    }
}
