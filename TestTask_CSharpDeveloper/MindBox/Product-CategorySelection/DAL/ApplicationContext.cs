
using Microsoft.EntityFrameworkCore;
using Product_CategorySelection.Code.Models;

namespace Product_CategorySelection.DAL
{
    public class ApplicationContext : DbContext
    {
        private readonly String _connection;
        public ApplicationContext(String connection)
        {
            _connection = connection;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connection);
        }
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
