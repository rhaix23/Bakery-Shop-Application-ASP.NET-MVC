using BakeryApplication.Models;
using BakeryApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BakeryApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public SearchController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var AllProducts = _productRepository.AllProducts;
            return Ok(AllProducts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productRepository.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Search([FromBody] string query)
        {
            IEnumerable<Product> products = new List<Product>();

            if (!string.IsNullOrEmpty(query))
            {
                products = _productRepository.Search(query);
            }

            return new JsonResult(products);
        }
    }
}
