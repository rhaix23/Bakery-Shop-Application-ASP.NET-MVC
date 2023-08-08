using BakeryApplication.Models;

namespace BakeryApplication.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> AllCategories => _applicationDbContext.Categories.OrderBy(p => p.Name);
    }
}
