using System.ComponentModel.DataAnnotations.Schema;

namespace SpaMvc.Models
{
    public class Product
    {
        public Int32 Id { get; set; }
        [Column("Product")]
        public String Name { get; set; } = null!;
        public Int32 Cost { get; set; }
        public String? Descriptions { get; set; }
        public String? Color { get; set; }
        public List<Category>? Categories { get; set; } = new();
    }
}
