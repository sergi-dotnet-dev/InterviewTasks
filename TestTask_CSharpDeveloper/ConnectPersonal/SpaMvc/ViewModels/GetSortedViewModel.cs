using SpaMvc.Models;

namespace SpaMvc.ViewModels
{
	public class GetSortedViewModel
	{
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
