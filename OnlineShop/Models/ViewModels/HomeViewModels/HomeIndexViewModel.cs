using OnlineShop.Data;

namespace OnlineShop.Models.ViewModels.HomeViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; } = default!;

        public string? Category { get; set; } = default;

        public int Page { get; set; }

        public int PageCount { get; set; }
    }
}
