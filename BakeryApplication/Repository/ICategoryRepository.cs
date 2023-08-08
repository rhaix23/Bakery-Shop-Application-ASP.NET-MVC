using BakeryApplication.Models;

namespace BakeryApplication.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get;}
    }
}
