namespace BakeryApplication.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            ApplicationDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Products.Any())
            {
                context.AddRange
                (
                    new Product
                    {
                        Name = "Ivory Indulgence",
                        Price = 500M,
                        ShortDescription = "A classic chocolate cake",
                        LongDescription = "A classic chocolate cake with a rich chocolate flavor and a creamy chocolate buttercream icing",
                        ImageUrl = "https://res.cloudinary.com/dtyzbmtlz/image/upload/v1685289948/american-heritage-chocolate-vdx5hPQhXFk-unsplash_qmh1u2.jpg",
                        IsProductOfTheWeek = true,
                        InStock = true,
                        Category = Categories["Classic"]
                    },
                    new Product
                    {
                        Name = "Vanilla and Chocolate Delights",
                        Price = 1200M,
                        ShortDescription = "A classic vanilla and chocolate cake",
                        LongDescription = "A classic vanilla and chocolate cake with a rich chocolate flavor and a creamy chocolate buttercream icing",
                        ImageUrl = "https://res.cloudinary.com/dtyzbmtlz/image/upload/v1685289951/aneta-voborilova-mlcm6qi9Bu8-unsplash_pluvp7.jpg",
                        IsProductOfTheWeek = true,
                        InStock = true,
                        Category = Categories["Premium"]
                    },
                    new Product
                    {
                        Name = "The Brownie Haven",
                        Price = 1500M,
                        ShortDescription = "A premium brownie cake",
                        LongDescription = "A premium brownie cake with a rich chocolate flavor and a creamy chocolate buttercream icing",
                        ImageUrl = "https://res.cloudinary.com/dtyzbmtlz/image/upload/v1685289951/david-holifield-kPxsqUGneXQ-unsplash_lmfmo0.jpg",
                        IsProductOfTheWeek = true,
                        InStock = true,
                        Category = Categories["Premium"]
                    },
                    new Product
                    {
                        Name = "Raspberry Magic",
                        Price = 700M,
                        ShortDescription = "A special raspberry cake",
                        LongDescription = "A special raspberry cake with a rich chocolate flavor and a creamy chocolate buttercream icing",
                        ImageUrl = "https://res.cloudinary.com/dtyzbmtlz/image/upload/v1685289947/amirali-mirhashemian-z1W2v1JWbKU-unsplash_gh6zwx.jpg",
                        IsProductOfTheWeek = false,
                        InStock = true,
                        Category = Categories["Specialty"],
                    },
                    new Product
                    {
                        Name = "Caramelized Vanilla Treats",
                        Price = 1000M,
                        ShortDescription = "A premium caramelized vanilla cake",
                        LongDescription = "A premium caramelized vanilla cake with a rich chocolate flavor and a creamy chocolate buttercream icing",
                        ImageUrl = "https://res.cloudinary.com/dtyzbmtlz/image/upload/v1685289947/swapnil-dwivedi-Nl8Oa6ZuNcA-unsplash_so866i.jpg",
                        IsProductOfTheWeek = false,
                        InStock = true,
                        Category = Categories["Premium"]
                    },
                    new Product
                    {
                        Name = "Blueberry Dream Cake",
                        Price = 1700M,
                        ShortDescription = "A premium blueberry cake",
                        LongDescription = "A premium blueberry cake with a rich chocolate flavor and a creamy chocolate buttercream icing",
                        ImageUrl = "https://res.cloudinary.com/dtyzbmtlz/image/upload/v1685289946/irina-jKh453Idils-unsplash_t65onm.jpg",
                        IsProductOfTheWeek = false,
                        InStock = true,
                        Category = Categories["Premium"]
                    }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var categoryList = new Category[]
                    {
                        new Category { Name = "Classic", Description="Classic cakes" },
                        new Category { Name = "Specialty", Description="Specialized flavored cakes" },
                        new Category { Name = "Premium", Description="High-quality cakes" },
                        new Category { Name = "Seasonal", Description="Cakes for certain seasons" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category category in categoryList)
                    {
                        categories.Add(category.Name, category);
                    }
                }
                return categories;
            }
        }
    }
}
