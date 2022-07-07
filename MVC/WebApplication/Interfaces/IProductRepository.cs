using MyWebApplication.Models;

namespace MyWebApplication.Interfaces
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll(int limit);
    }
}
