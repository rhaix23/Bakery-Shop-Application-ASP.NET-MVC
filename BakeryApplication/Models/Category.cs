namespace BakeryApplication.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public List<Product>? Breads { get; set; }
    }
}
