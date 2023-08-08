using BakeryApplication.Models;

namespace BakeryApplication.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Product> ProductOfTheWeek { get; set; }

        public HomeViewModel(IEnumerable<Product> productOfTheWeek) 
        { 
            ProductOfTheWeek = productOfTheWeek;
        }
    }
}
