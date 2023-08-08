using BakeryApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BakeryApplication.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Product> AllProducts => _applicationDbContext.Products.Include(p => p.Category);
            
        public IEnumerable<Product> ProductsOfTheWeek => _applicationDbContext.Products.Include(p => p.Category).Where(p => p.IsProductOfTheWeek);   

        public Product? GetProductById(int productId) => _applicationDbContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == productId);

        public IEnumerable<Product> Search(string query)
        {
            return _applicationDbContext.Products.Where(p => p.Name.Contains(query));   
        }
    }
}
