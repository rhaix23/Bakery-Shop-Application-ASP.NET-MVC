using BakeryApplication.Models;
using BakeryApplication.Repository;
using BakeryApplication.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BakeryApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var productOfTheWeek = _productRepository.ProductsOfTheWeek;
            var homeViewModel = new HomeViewModel(productOfTheWeek); 
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}