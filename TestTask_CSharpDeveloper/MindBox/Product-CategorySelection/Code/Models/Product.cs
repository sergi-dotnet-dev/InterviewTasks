using System.ComponentModel.DataAnnotations.Schema;

namespace Product_CategorySelection.Code.Models
{
    public class Product
    {
        public Int32 Id { get; set; }
        [Column("Product")]
        public String Name { get; set; } = null!;
        public List<Category>? Categories { get; set; } = new();
    }
}
