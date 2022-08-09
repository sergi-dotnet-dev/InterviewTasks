using System.ComponentModel.DataAnnotations.Schema;

namespace SpaMvc.Models
{
    public class Category
    {
        public Int32 Id { get; set; }
        [Column("Category")]
        public String Name { get; set; } = null!;
        public List<Product>? Product { get; set; } = new();

        public override bool Equals(object? obj)
        {
            var other = obj as Category;
            if (other == null) 
                return false;
            if (other.Id == Id || other.Name == Name) 
                return true;
            return false;
        }
    }
}