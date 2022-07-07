namespace MyWebApplication.Models
{
    public class EditProductViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
