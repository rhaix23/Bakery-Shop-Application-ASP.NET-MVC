using BakeryApplication.Models;

namespace BakeryApplication.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> ProductsOfTheWeek { get; }
        Product? GetProductById(int productId);
        IEnumerable<Product> Search(string query);
    }
}
