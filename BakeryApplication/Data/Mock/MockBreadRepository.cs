using BakeryApplication.Models;
using BakeryApplication.Repository;

namespace BakeryApplication.Data.Mock
{
    public class MockBreadRepository : IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> AllProducts => new List<Product>
        {
            new Product { Id = 1, Name = "Apple Pie", Price = 12.95M, ShortDescription = "Our famous apple pies!", LongDescription = "Icing carrot cake jelly beans. Toffee chocolate cake jelly-o chocolate bar. Jelly-o chocolate bar chocolate cake chocolate cake. Toffee chocolate cake jelly beans. Tof", Category = _categoryRepository.AllCategories.ToList()[0], ImageUrl="https://upload.wikimedia.org/wikipedia/commons/3/33/Fresh_made_bread_05.jpg", InStock=true,IsProductOfTheWeek=false}
        };

        public IEnumerable<Product> ProductsOfTheWeek 
        { 
            get
            {
                return AllProducts.Where(b => b.IsProductOfTheWeek); 
            }  
        }

        public Product? GetProductById(int productId)
        {
            return AllProducts.FirstOrDefault(b => b.Id == productId);
        }

        public IEnumerable<Product> Search(string query)
        {
            throw new NotImplementedException();
        }
    }
}
