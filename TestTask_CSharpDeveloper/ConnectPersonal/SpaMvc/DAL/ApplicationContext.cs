using Microsoft.EntityFrameworkCore;
using SpaMvc.Models;

namespace SpaMvc.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Category { get; set; }
    }
}
