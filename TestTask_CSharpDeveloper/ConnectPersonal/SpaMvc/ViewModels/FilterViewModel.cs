using Microsoft.AspNetCore.Mvc.Rendering;
using SpaMvc.Models;

namespace SpaMvc.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Category> categories, int? category)
        {
            categories.Insert(0, new Category { Name = "Все", Id = 0 });
            Categories = new SelectList(categories, "Id", "Name", category);
            SelectedCategory = category;
        }
        public SelectList Categories { get; private set; }
        public int? SelectedCategory { get; private set; }
    }
}
