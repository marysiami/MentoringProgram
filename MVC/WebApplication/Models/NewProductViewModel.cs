namespace MyWebApplication.Models
{
    public class NewProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
