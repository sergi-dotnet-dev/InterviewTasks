using System.ComponentModel.DataAnnotations.Schema;

namespace Product_CategorySelection.Code.Models
{
    public class Category
    {
        public Int32 Id { get; set; }
        [Column("Category")]
        public String Name { get; set; } = null!;
        public Int32 ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
