using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Product_CategorySelection.Code;
using Product_CategorySelection.Code.Models;
using Product_CategorySelection.DAL;

namespace Product_CategorySelection
{
    public static class Program
    {
        private static ApplicationContext _context;
        private static ServerConnect ServerConnect = new();
        private static String connectionString = ServerConnect.GetConnection();
        static async Task Main(string[] args)
        {
            using (_context = new(connectionString))
            {
                SeedDb(_context); //Наполнение базы некоторыми значениями с присвоением продуктам 0, 1 и более категории
                //Product_CategoryOutput(_context); //Вывод с помощью EF Core и LINQ
                await Product_CategoryOutputAsync(); // Вывод в консоль с помощью запроса
            }
        }
        private static void SeedDb(ApplicationContext context)
        {
            Category category1 = new Category { Name = "c1" };
            Category category2 = new Category { Name = "c2" };
            Category category3 = new Category { Name = "c3" };
            Category category4 = new Category { Name = "c4" };
            Category category5 = new Category { Name = "c5" };
            context.Categories.AddRange(category1, category2, category3, category4, category5);

            Product product1 = new Product() { Name = "p1" };
            Product product2 = new Product() { Name = "p2" };
            Product product3 = new Product() { Name = "p3" };
            Product product4 = new Product() { Name = "p4" };
            Product product5 = new Product() { Name = "p5" };
            context.Products.AddRange(product1, product2, product3, product4, product5);

            product1.Categories.Add(category3);
            product2.Categories.Add(category1);
            product4.Categories.Add(category4);
            product4.Categories.Add(category2);
            product4.Categories.Add(category5);
            context.SaveChanges();
        }
        private static void Product_CategoryOutput(ApplicationContext context)
        {
            Console.WriteLine("Name\t\t\tCategory");
            var products = context.Products
                .Include(p => p.Categories)
                .ToList();
            foreach (var product in products)
            {
                Console.Write($"{product.Name}\t\t\t");
                foreach (var category in product.Categories)
                {
                    if (category == null) { Console.Write('\n'); break; }
                    Console.Write($"{category.Name} ");
                }
                Console.Write('\n');
            }

        }
        private static async Task Product_CategoryOutputAsync()
        {
            String sqlExpression = "SELECT Products.Product, Categories.Category from Products left outer join Categories on Categories.ProductId = Products.Id";

            using (SqlConnection conn = new(connectionString))
            {
                await conn.OpenAsync();

                SqlCommand command = new(sqlExpression, conn);

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        Console.WriteLine($"Product\t\t\tCategory");
                        while (await reader.ReadAsync())
                        {
                            String productName = (String)reader["Product"];
                            String categoryName = reader["Category"] == DBNull.Value ? String.Empty : (String)reader["Category"];
                            Console.WriteLine($"{productName}\t\t\t{categoryName}");
                        }
                    }
                }
            }
        }
    }
}