using MyWebApplication.Models;

namespace MyWebApplication.Interfaces
{
    public interface IProductService
    {
        public NewProductViewModel GetEmptyProductViewModel();
        public EditProductViewModel GetEditProductViewModel(int id);
        public List<ListProductViewModel> GetProducts();
        public Task CreateNewProduct(ProductViewModel product);
        public void UpdateProduct(ProductViewModel product);
    }
}
