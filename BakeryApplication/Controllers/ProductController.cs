using BakeryApplication.Repository;
using BakeryApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            ProductListViewModel productsListViewModel = new(_productRepository.AllProducts, "Croissants");

            return View(productsListViewModel);
        }
        
        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
