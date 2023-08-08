using Moq;
using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApplication.Models;
using BakeryApplication.Repository;

namespace BakeryApplicationTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Apple Pie",
                    Price = 12.95M,
                    ShortDescription = "Our famous apple pies!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Id = 1,
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/applepie.jpg",
                    InStock = true,
                    IsProductOfTheWeek = true,
                },
                new Product
                {
                    Name = "Blueberry Cheese Cake",
                    Price = 18.95M,
                    ShortDescription = "You'll love it!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Id = 2,
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                    InStock = true,
                    IsProductOfTheWeek = false,
                },
                new Product
                {
                    Name = "Strawberry Pie",
                    Price = 15.95M,
                    ShortDescription = "Our delicious strawberry pie!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Id = 3,
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypie.jpg",
                    InStock = true,
                    IsProductOfTheWeek = false,
                },
                new Product
                {
                    Name = "Rhubarb Pie",
                    Price = 15.95M,
                    ShortDescription = "My God, so sweet!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Id = 4,
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpie.jpg",
                    InStock = true,
                    IsProductOfTheWeek = false,
                },
                new Product
                {
                    Name = "Blueberry Cheese Cake",
                    Price = 18.95M,
                    ShortDescription = "You'll love it!",
                    LongDescription =
                        "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
                    Id = 5,
                    ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/blueberrycheesecake.jpg",
                    InStock = false,
                    IsProductOfTheWeek = true,
                },
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.AllProducts).Returns(products);
            mockProductRepository.Setup(repo => repo.ProductsOfTheWeek).Returns(products.Where(p => p.IsProductOfTheWeek));
            mockProductRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(products[0]);
            return mockProductRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    Id = 1,
                    Name = "Fruit Pies",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Cheese cakes",
                    Description = "Lorem ipsum"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Fruit Pies",
                    Description = "Seasonal pies"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);
            return mockCategoryRepository;
        }

        private static Dictionary<string, Category>? _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { Name = "Fruit pies" },
                        new Category { Name = "Cheese cakes" },
                        new Category { Name = "Seasonal pies" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (var genre in genresList)
                    {
                        _categories.Add(genre.Name, genre);
                    }
                }

                return _categories;
            }
        }
    }
}